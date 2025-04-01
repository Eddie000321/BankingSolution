using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppClassLibrary
{
   public enum AccountExceptionType
    {
     ACCOUNT_DOES_NOT_EXIST,
     ACCOUNT_ALREADY_EXIST,
     INSUFFICIENT_FUNDS,
     NO_OVERDRAFT_FOR_THIS_ACCOUNT,
     PASSWORD_INCORRECT,
     USER_DOES_NOT_EXIST,
     USER_ALREADY_EXIST,
     USER_NOT_LOGGED_IN,
     NAME_NOT_ASSOCIATED_WITH_ACCOUNT, // added for SavingAccount.cs
     CREDIT_LIMIT_HAS_BEEN_EXCEEDED, // add missing part
    }
}
