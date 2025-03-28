using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction
{
    public struct Transaction
    {
        // Properties with public getter and no setter
        public string AccountNumber { get; }
        public decimal Amount { get; }
        public Person Originator { get; }
        public DateTime Time { get; }

        // Constructor
        public Transaction(string accountNumber, decimal amount, Person person)
        {
            AccountNumber = accountNumber;
            Amount = amount;
            Originator = person;
            Time = Util.Now; // Initialized with Util.Now property
        }

        // ToString override
        public override string ToString()
        {
            string transactionType = Amount >= 0 ? "Deposit" : "Withdraw";
            return $"{transactionType}: Account #{AccountNumber}, " +
                   $"Name: {Originator.Name}, Amount: {Math.Abs(Amount):C}, Time: {Time}";
        }
    }
}
