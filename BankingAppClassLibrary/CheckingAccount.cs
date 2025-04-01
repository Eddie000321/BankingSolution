using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppClassLibrary
{
    public class CheckingAccount : Account
    {
        private const decimal COST_PER_TRANSACTION = 0.05m;
        private const decimal INTEREST_RATE = 0.005m;
        private bool hasOverdraft;

        public CheckingAccount(decimal balance = 0, bool hasOverdraft = false)
            : base("CK", balance) => this.hasOverdraft = hasOverdraft;

        public new void Deposit(decimal amount, Person person)
        {
            base.Deposit(amount, person);
            OnTransactionOccur(this, new TransactionEventArgs(person.Name, amount, true));
        }

        public void Withdraw(decimal amount, Person person)
        {
            if (!IsUser(person) || !person.IsAuthenticated)
            {
                OnTransactionOccur(this, new TransactionEventArgs(person.Name, amount, false));                
            }

            if (Balance - amount < 0 && !hasOverdraft)
            {
                OnTransactionOccur(this, new TransactionEventArgs(person.Name, amount, false));               
            }

            base.Deposit(-amount, person);
            OnTransactionOccur(this, new TransactionEventArgs(person.Name, amount, true));
        }

        public override void PrepareMonthlyReport()
        {
            // +	PrepareMonthlyReport() 			: void
            // public override void PrepareMonthlyReport( )
            Balance += (LowestBalance * INTEREST_RATE) / 12 - transactions.Count * COST_PER_TRANSACTION;
            transactions.Clear();
        }
    }
    }
