using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingAppClassLibrary;

namespace BankingAppClassLibrary
{
    public abstract class Account
    {
        private static int LAST_NUMBER = 100000;
        private readonly List<Person> users;
        public readonly List<Transaction> transactions;
        public event TransactionEventHandler OnTransaction;

        public string Number { get; }
        protected decimal Balance { get; set; }
        protected decimal LowestBalance { get; set; }

        public Account(string type, decimal balance)
        {
            Number = type + LAST_NUMBER;
            LAST_NUMBER++;
            Balance = balance;
            LowestBalance = balance;
            users = new List<Person>();
            transactions = new List<Transaction>();
        }

        protected void Deposit(decimal amount, Person person)
        {
            Balance += amount;
            if (Balance < LowestBalance)
            {
                LowestBalance = Balance;
            }

            Transaction transaction = new Transaction(Number, amount, person);
            transactions.Add(transaction);
        }

        public void AddUser(Person user)
        {
            users.Add(user);
        }

        public bool IsUser(Person user)
        {
            foreach (var accUser in users)
            {
                if (accUser.Name == user.Name) return true;
            }
            return false;
        }

        public virtual void OnTransactionOccur(object sender, TransactionEventArgs e)
        {
            OnTransaction?.Invoke(sender, e);
        }

        public abstract void PrepareMonthlyReport();

        // +	«abstract» PrepareMonthlyStatement(): void

        // 5.	public abstract void PrepareMonthlyReport( )– This abstract public method does not take any parameter nor does it return a value.
        // Research how to declare an abstract method.


        public override string ToString()
        {
            string result = $"Account Number: {Number}\nBalance: {Balance}\nUsers:\n";
            foreach (var user in users)
            {
                result += $"- {user.Name}\n";
            }
            result += "Transactions:\n";
            foreach (var transaction in transactions)
            {
                result += $"- {transaction}\n";
            }
            return result;
        }
    }
    }
