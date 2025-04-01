﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppClassLibrary
{
    public class Delegates // change internal to public
    {
        public delegate void TransactionEventHandler(
       object sender,
       TransactionEventArgs e);
        public delegate void LoginEventHandler(
            object sender,
            LoginEventArgs e);
    }
}
