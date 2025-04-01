using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingAppClassLibrary;
using static BankingAppClassLibrary.Delegates;

namespace BankingAppClassLibrary
{
    public class Person
    {
        // fields
        private string password;
        public event LoginEventHandler OnLogin; // Its delegates.  
        /*
            public delegate void LoginEventHandler(object sender,LoginEventArgs e); -> Delegates.cs
         */
        /*
         public class LoginEventArgs : EventArgs
    {
        public string PersonName { get; }
        public bool Success { get; }
        public DayTime Time { get; }
        public LoginEventType EventType { get; }

        public LoginEventArgs(string name, bool success, LoginEventType eventType)
        {
            PersonName = name;
            Success = success;
            EventType = eventType;
            Time = Util.Now;
        }
    }   */
        // properties
        public string Sin { get; }
        public string Name { get; }
        public bool IsAuthenticated { get; private set; }

        // constructor
        public Person(string name, string sin)
        {
            Name = name;
            Sin = sin;
            password = sin.Substring(0, 3); // first 3 digits of sin 0,1,2
        }

        public void Login(string password)
        {
            if (password != this.password) // if pass is incorrect
            {
                IsAuthenticated = false;
                OnLogin(this, new LoginEventArgs(Name, false,LoginEventType.Login));
                throw new AccountException(AccountExceptionType.PASSWORD_INCORRECT);
            }
            else // else pass is correct
            {
                IsAuthenticated = true;
                OnLogin(this, new LoginEventArgs(Name, true, LoginEventType.Login)); // -> send login event type to Login args   
            }
        }

        public void Logout()
        {
            if (OnLogin != null)
            {
                IsAuthenticated = false; // set to false
                OnLogin(this, new LoginEventArgs( // same as login but LognEventType is Logout
                    Name,
                    true,
                    LoginEventType.Logout
                ));
            }
        }
        
        public override string ToString()
        {
            return $"{Name} [{Sin}] {(IsAuthenticated ? "authenticated" : "not authenticated")}";
        }
    }
}