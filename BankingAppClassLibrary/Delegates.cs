using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppClassLibrary
{
    internal class Delegates
    {
        public delegate void TransactionEventHandler(
       object sender,
       TransactionEventArgs e);
        public delegate void LoginEventHandler(
            object sender,
            LoginEventArgs e);
    }
}
