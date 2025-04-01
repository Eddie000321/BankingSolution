using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingAppClassLibrary;

namespace BankingAppClassLibrary
{
    public class VisaAccount : Account
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
            // ✅ FIXED: Pass correct sender and event args to base event handler
            OnTransactionOccur(this, new TransactionEventArgs(
                person.Name, amount, true));
        }

        // DoPurchase Method
        public void DoPurchase(decimal amount, Person person)
        {
            // ✅ FIXED: Replaced non-existent IsPersonAssociated() with IsUser()
            if (!IsUser(person))
            {
                OnTransactionOccur(this, new TransactionEventArgs(
                    person.Name, -amount, false));

                // ✅ FIXED: Replaced hardcoded string with proper exception enum
                throw new AccountException(AccountExceptionType.NAME_NOT_ASSOCIATED_WITH_ACCOUNT);
            }

            // ✅ FIXED: Replaced IsLoggedIn with correct IsAuthenticated
            if (!person.IsAuthenticated)
            {
                OnTransactionOccur(this, new TransactionEventArgs(
                    person.Name, -amount, false));
                throw new AccountException(AccountExceptionType.USER_NOT_LOGGED_IN);
            }

            if ((Balance + creditLimit) < amount)
            {
                OnTransactionOccur(this, new TransactionEventArgs(
                    person.Name, -amount, false));
                throw new AccountException(AccountExceptionType.CREDIT_LIMIT_HAS_BEEN_EXCEEDED);
            }

            // ✅ FIXED: Always call Deposit first, then fire success event
            Deposit(-amount, person); // Withdraw by depositing negative
            OnTransactionOccur(this, new TransactionEventArgs(
                person.Name, -amount, true));
        }

        // PrepareMonthlyReport Method
        public override void PrepareMonthlyReport()
        {
            decimal interest = (LowestBalance * INTEREST_RATE) / 12;
            Balance -= interest;

            // ✅ FIXED: Field name is 'transactions', not 'Transactions'
            transactions.Clear(); // Re-initialize
        }
    }
}
