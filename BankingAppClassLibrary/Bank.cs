using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppClassLibrary
{
    public static class Bank
    {
        public static readonly Dictionary<string, Account> ACCOUNTS = new();
        public static readonly Dictionary<string, Person> USERS = new();

        static Bank()
        {
            // Initialize users
            AddUser("Narendra", "1234-5678");
            AddUser("Ilia", "2345-6789");
            AddUser("Mehrdad", "3456-7890");
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
            AddUserToAccount("SV-100002", "Jake");

            AddUserToAccount("SV-100003", "Mayy");
            AddUserToAccount("SV-100003", "Nicoletta");

            AddUserToAccount("CK-100004", "Mehrdad");
            AddUserToAccount("CK-100004", "Arben");
            AddUserToAccount("CK-100004", "Yin");

            AddUserToAccount("CK-100005", "Jake");
            AddUserToAccount("CK-100005", "Nicoletta");

            AddUserToAccount("VS-100006", "Ilia");
            AddUserToAccount("VS-100006", "Vinay");

            AddUserToAccount("SV-100007", "Patrick");
            AddUserToAccount("SV-100007", "Hao");
        }

        public static void AddUser(string name, string sin)
        {
            if (USERS.ContainsKey(name))
                throw new AccountException(AccountExceptionType.USER_ALREADY_EXIST);

            Person p = new(name, sin);
            p.OnLogin += Logger.LoginHandler;
            USERS[name] = p;
        }

        public static void AddAccount(Account account)
        {
            account.OnTransaction += Logger.TransactionHandler;
            ACCOUNTS[account.Number] = account;
        }

        public static void AddUserToAccount(string accountNumber, string userName)
        {
            if (!ACCOUNTS.ContainsKey(accountNumber))
                throw new AccountException(AccountExceptionType.ACCOUNT_DOES_NOT_EXIST);

            if (!USERS.ContainsKey(userName))
                throw new AccountException(AccountExceptionType.USER_DOES_NOT_EXIST);

            ACCOUNTS[accountNumber].AddUser(USERS[userName]);
        }

        public static Account GetAccount(string number)
        {
            if (ACCOUNTS.TryGetValue(number, out Account account))
                return account;

            throw new AccountException(AccountExceptionType.ACCOUNT_DOES_NOT_EXIST);
        }

        public static Person GetUser(string name)
        {
            if (USERS.TryGetValue(name, out Person user))
                return user;

            throw new AccountException(AccountExceptionType.USER_DOES_NOT_EXIST);
        }

        public static void PrintAccounts()
        {
            foreach (var account in ACCOUNTS.Values)
            {
                Console.WriteLine(account);
                Console.WriteLine();
            }
        }

        public static void PrintUsers()
        {
            foreach (var user in USERS.Values)
            {
                Console.WriteLine(user);
            }
        }

        public static void SaveAccounts(string filename)
        {
            string json = JsonSerializer.Serialize(ACCOUNTS, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filename, json);
        }

        public static void SaveUsers(string filename)
        {
            string json = JsonSerializer.Serialize(USERS, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filename, json);
        }

        public static List<Transaction> GetAllTransactions()
        {
            List<Transaction> allTransactions = new();
            foreach (var account in ACCOUNTS.Values)
                allTransactions.AddRange(account.transactions);

            return allTransactions;
        }
    }
}
