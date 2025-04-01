using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace BankingAppClassLibrary
{
    public static class Bank
    {
        //Fields
        public static readonly Dictionary<string, Account> ACCOUNTS = new Dictionary<string, Account>(); // readonly means that the reference can't be changed,
        // Dictionary <key, value> key=account Num is string, value is Account           // but the object itself can be modified.
        public static readonly Dictionary<string, Person> USERS = new Dictionary<string, Person>();
        // Dictionary <key, value> key=sin is string, value is Person

        // Methods
        // Constructor
        static Bank()
        {
            // Initialize users
            AddUser("Narendra", "1234-5678"); // Orignal was AddPerson. So i changed it to AddUser
            AddUser("Ilia", "2345-6789"); // theres No AddPerson in the project.
            AddUser("Mehrdad", "3456-7890"); // Person.cs is only handling user login and logout.
            AddUser("Vinay", "4567-8901");
            AddUser("Arben", "5678-9012");
            AddUser("Patrick", "6789-0123");
            AddUser("Yin", "7890-1234");
            AddUser("Hao", "8901-2345");
            AddUser("Jake", "9012-3456");
            AddUser("Mayy", "1224-5678");
            AddUser("Nicoletta", "2344-6789");

            // Initialize accounts
            AddAccount(new VisaAccount());              // VS-100000
            AddAccount(new VisaAccount(150, -500));     // VS-100001
            AddAccount(new SavingAccount(5000));        // SV-100002
            AddAccount(new SavingAccount());            // SV-100003
            AddAccount(new CheckingAccount(2000));      // CK-100004
            AddAccount(new CheckingAccount(1500, true));// CK-100005
            AddAccount(new VisaAccount(50, -550));      // VS-100006
            AddAccount(new SavingAccount(1000));        // SV-100007

            // Associate users with accounts
            AddUserToAccount("VS-100000", "Narendra");
            AddUserToAccount("VS-100000", "Ilia");
            AddUserToAccount("VS-100000", "Mehrdad");

            AddUserToAccount("VS-100001", "Vinay");
            AddUserToAccount("VS-100001", "Arben");
            AddUserToAccount("VS-100001", "Patrick");

            AddUserToAccount("SV-100002", "Yin");
            AddUserToAccount("SV-100002", "Hao");
        }
        
        public static void PrintAccounts()
        {
            // 1) public static void PrintAccounts() 
            //This method prints all the accounts in the ACCOUNTS collection to the console.
            foreach (Account acc in ACCOUNTS.Values)
            {
                Console.WriteLine(acc);
                Console.WriteLine();
            }
        }

        public static void PrintUsers()
        {
            // 2) public static void PrintUsers()
            // This method prints all persons in the USERS collection to the console.
            foreach (Person person in USERS.Values)
            {
                Console.WriteLine($"{person.Name} [{person.Sin}] Authenticated: {person.IsAuthenticated}");
            }
        }

        public static void SaveAccounts(string filename)
        {
            // 3) public static void SaveAccounts(string filename)
            // This method serializes all ACCOUNTS to a JSON file.
            string json = JsonSerializer.Serialize(ACCOUNTS, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filename, json);
        }

        public static void SaveUsers(string filename)
        {
            // 4) public static void SaveUsers(string filename)
            // This method serializes all USERS to a JSON file.
            string json = JsonSerializer.Serialize(USERS, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filename, json);
        }

        public static Person GetUser(string name)
        {
            // 5) public static Person GetUser(string name)
            //    Takes a string (person's name), returns matching Person object.
            //      a) Check if there's a Person with that 'Name' in USERS
            //      b) If found, return it
            //      c) Else throw AccountException(USER_DOES_NOT_EXIST)
            //    This method does not display anything on screen.
            // Because key=sin in USERS, we loop Values to compare .Name
            foreach (Person person in USERS.Values) 
            {
                if (person.Name == name)
                {
                    return person;
                }
            }
            throw new AccountException(AccountExceptionType.USER_DOES_NOT_EXIST); // AccountExectiopnType.cs
        }

        public static Account GetAccount(string number)
        {
            // 6) public static Account GetAccount(string number)
            //    Takes a string (account number), returns matching Account.
            //      a) Checks if ACCOUNTS has key=number
            //      b) If yes, return value
            //      c) Else throw AccountException(ACCOUNT_DOES_NOT_EXIST)
            if (ACCOUNTS.ContainsKey(number))
            {
                return ACCOUNTS[number];
            }
            else
            {
                throw new AccountException(AccountExceptionType.ACCOUNT_DOES_NOT_EXIST);
            }
        }

        public static void AddUser(string name, string sin)
        {
            // 7) public static void AddUser(string name, string sin)
            //    Takes two strings, does:
            //      a) If sin is already a key in USERS, throw
            //      b) Else create Person(name, sin)
            //         i) Hook Person's OnLogin event to Logger.LoginHandler
            //         ii) USERS[sin] = that new Person
            if (USERS.ContainsKey(sin))
            {
                throw new AccountException(AccountExceptionType.USER_ALREADY_EXIST);
            }
            else
            {
                Person p = new Person(name, sin); // make a new person 
                p.OnLogin += Logger.LoginHandler; // Person p connects to Logger.LoginHandler
                USERS[sin] = p; // add the new person to USERS dictionary. key is sin, value is person
            }
        }

        public static void AddAccount(Account account)
        {
            // 8) public static void AddAccount(Account account)
            // Takes an account object and:
            // a) OnTransaction += Logger.TransactionHandler
            // b) ACCOUNTS[account.Number] = account
            if (ACCOUNTS.ContainsKey(account.Number))
            {
                throw new AccountException(AccountExceptionType.ACCOUNT_ALREADY_EXIST);
            }
            else
            {
                account.OnTransaction += Logger.TransactionHandler;
                ACCOUNTS[account.Number] = account; // add to dictionary key is account.Number, value is account
            }
        }

        public static void AddUserToAccount(string number, string name)
        {
            // 9) public static void AddUserToAccount(string number, string name)
            //    – Takes two strings (accNumber, userName) and:
            //      a) Locates the account (GetAccount(number))
            //      b) Locates the person (GetUser(name))
            //      c) Calls account.AddUser(person)
            Account acc = GetAccount(number); // call GetAccount to get the account
            Person user = GetUser(name); // call GetUser to get the user
            acc.AddUser(user); // add the user to the account
        }
    }
}
    