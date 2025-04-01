using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingAppClassLibrary;

namespace BankingAppClassLibrary
{
    public class SavingAccount : Account, ITransaction
    {
        // Class variables (static readonly)
        private static readonly decimal COST_PER_TRANSACTION = 0.5m;   // 1) per transaction cost
        private static readonly decimal INTEREST_RATE = 0.015m;        // 2) annual interest rate

        // Constructor
        // public SavingAccount(decimal balance = 0) – base constructor with string “SV” and balance
        public SavingAccount(decimal balance = 0)
            : base("SV", balance)
        {
            // No extra logic needed, base sets Number to "SV-xxxxx" and initial balance
        }

        // 1) public new void Deposit(decimal amount, Person person)
        // Calls base deposit logic, then OnTransactionOccur event
        public new void Deposit(decimal amount, Person person)
        {
            // base class might have something like: protected void ProcessTransaction(amount, person)
            // or a base.Deposit method – here we assume 'ProcessTransaction'
            base.ProcessTransaction(amount, person);

            // After deposit success, call OnTransactionOccur
            base.OnTransactionOccur(
                this,
                new TransactionEventArgs(
                    person.Name,
                    amount,
                    true // success
                )
            );
        }

        // 2) public void Withdraw(decimal amount, Person person)
        // Checking ownership, authentication, and balance
        public void Withdraw(decimal amount, Person person)
        {
            // (a) If person not associated with this account
            if (!this.IsUser(person))
            {
                base.OnTransactionOccur(
                    this,
                    new TransactionEventArgs(person.Name, -amount, false)
                );
                throw new AccountException(AccountExceptionType.NAME_NOT_ASSOCIATED_WITH_ACCOUNT);
            }

            // (b) If person not logged in
            if (!person.IsAuthenticated)
            {
                base.OnTransactionOccur(
                    this,
                    new TransactionEventArgs(person.Name, -amount, false)
                );
                throw new AccountException(AccountExceptionType.USER_NOT_LOGGED_IN);
            }

            // (c) If withdrawal amount is greater than the balance
            if (amount > this.Balance)
            {
                base.OnTransactionOccur(
                    this,
                    new TransactionEventArgs(person.Name, -amount, false)
                );
                throw new AccountException(AccountExceptionType.INSUFFICIENT_FUNDS);
            }

            // (d) Otherwise success
            // "calls the Deposit() method of the base class with negative of the amount"
            // Here we assume the parent's logic is in 'ProcessTransaction(-amount, person)'
            // then OnTransactionOccur with success = true
            base.ProcessTransaction(-amount, person);
            base.OnTransactionOccur(
                this,
                new TransactionEventArgs(person.Name, -amount, true)
            );
        }

        // 3) public override void PrepareMonthlyReport()
        // - override the parent's abstract method
        // - compute service charge, interest, adjust balance, clear transactions
        public override void PrepareMonthlyReport()
        {
            // (a) service charge = number of transactions * COST_PER_TRANSACTION
            decimal serviceCharge = this.transactions.Count * COST_PER_TRANSACTION;

            // (b) interest = (LowestBalance * INTEREST_RATE) / 12
            decimal interest = (this.LowestBalance * INTEREST_RATE) / 12;

            // (c) adjust the balance
            this.Balance += interest;    // add interest
            this.Balance -= serviceCharge; // subtract service charge

            // (d) re-initialize transaction list
            this.transactions.Clear();
        }
    }
}