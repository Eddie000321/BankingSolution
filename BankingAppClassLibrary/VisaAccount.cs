using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppClassLibrary
{
    public class VisaAccount : Account, ITransaction
    {
        private decimal creditLimit;
        private const decimal INTEREST_RATE = 0.1995m;

        // Constructor
        public VisaAccount(decimal balance = 0, decimal creditLimit = 1200)
            : base("VS", balance)
        {
            this.creditLimit = creditLimit;
        }

        // DoPayment Method
        public void DoPayment(decimal amount, Person person)
        {
            Deposit(amount, person);
            OnTransactionOccur(new TransactionEventArgs(
                person.Name, amount, true));
        }

        // DoPurchase Method
        public void DoPurchase(decimal amount, Person person)
        {
            if (!IsPersonAssociated(person))
            {
                OnTransactionOccur(new TransactionEventArgs(
                    person.Name, -amount, false));
                throw new AccountException("Person not associated with this account.");
            }

            if (!person.IsLoggedIn)
            {
                OnTransactionOccur(new TransactionEventArgs(
                    person.Name, -amount, false));
                throw new AccountException("Person not logged in.");
            }

            if ((Balance + creditLimit) < amount)
            {
                OnTransactionOccur(new TransactionEventArgs(
                    person.Name, -amount, false));
                throw new AccountException("Purchase exceeds credit limit.");
            }

            OnTransactionOccur(new TransactionEventArgs(
                person.Name, -amount, true));
            Deposit(-amount, person); // Withdraw by depositing negative
        }

        // PrepareMonthlyReport Method
        public override void PrepareMonthlyReport()
        {
            decimal interest = (LowestBalance * INTEREST_RATE) / 12;
            Balance -= interest;
            Transactions.Clear(); // Re-initialize
        }
    }
}
