using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppClassLibrary
{
    public class TransactionEventArgs : LoginEventArgs
    {
        public decimal Amount { get; }

        public TransactionEventArgs(string personName, decimal amount, bool success)
            : base(personName, success, LoginEventType.None)
        {
            Amount = amount;
        }
    }

    // Delegate definitions
    public delegate void TransactionEventHandler(object sender, TransactionEventArgs e);
    public delegate void LoginEventHandler(object sender, LoginEventArgs e);
}
