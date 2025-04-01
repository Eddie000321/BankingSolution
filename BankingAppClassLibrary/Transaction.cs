using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppClassLibrary
{
    public struct Transaction
    {

        public string AccountNumber { get; }
        public decimal Amount { get; }
        public Person Originator { get; }
        public DayTime Time { get; } // Datetime Changed to DayTime

        // Constructor
        public Transaction(string accountNumber, decimal amount, Person person)
        {
            AccountNumber = accountNumber;
            Amount = amount;
            Originator = person;
            Time = Util.Now; // Initialized with Util.Now property
        }

        public override string ToString()
        {
            string transactionType;
            if (Amount >= 0)
            {
                transactionType = "Deposit";
            }
            else
            {
                transactionType = "Withdraw";
            }

            string result = transactionType + ": Account #" + AccountNumber +
                            ", Name: " + Originator.Name +
                            ", Amount: " + Math.Abs(Amount).ToString("C") +
                            ", Time: " + Time;

            return result;
        }

    }
}
