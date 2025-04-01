using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingAppClassLibrary;

namespace BankingAppClassLibrary
{
    public static class Logger
    {
        private static List<string> loginEvents = new List<string>();
        private static List<string> transactionEvents = new List<string>();

        public static void LoginHandler(object sender, LoginEventArgs args)
        {
            string logEntry = $"Person: {args.PersonName}, Success: {args.Success}";
            loginEvents.Add(logEntry);
        }

        public static void TransactionHandler(object sender, TransactionEventArgs args)
        {
            string logEntry = $"Person: {args.PersonName}, Amount: {args.Amount}, Operation: {args.Operation}, Success: {args.Success}";
            transactionEvents.Add(logEntry);
        }

        public static void DisplayLoginEvents()
        {
            Console.WriteLine("Login Events:");
            for (int i = 0; i < loginEvents.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {loginEvents[i]}");
            }
        }

        public static void DisplayTransactionEvents()
        {
            Console.WriteLine("Transaction Events:");
            for (int i = 0; i < transactionEvents.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {transactionEvents[i]}");
            }
        }
    }
    /* what is this?
    public class LoginEventArgs : EventArgs
    {
        public string PersonName { get; }
        public bool Success { get; }

        public LoginEventArgs(string personName, bool success)
        {
            PersonName = personName;
            Success = success;
        }
    }

    public class TransactionEventArgs : EventArgs
    {
        public string PersonName { get; }
        public decimal Amount { get; }
        public string Operation { get; }
        public bool Success { get; }

        public TransactionEventArgs(string personName, decimal amount, string operation, bool success)
        {
            PersonName = personName;
            Amount = amount;
            Operation = operation;
            Success = success;
        }
    }
}
*/
}