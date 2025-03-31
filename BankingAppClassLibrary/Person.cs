using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppClassLibrary
{
    public class Person
    {
        // fields
        private string password;
        public event LoginEventHandler OnLogin; // Its delegates. 
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
            IsAuthenticated = false; // bool default value is false
        }

        public void Login(string pwd)
        {
            if (pwd != password)
            {
                IsAuthenticated = false;
                if (OnLogin != null)
                {
                    OnLogin(this, new LoginEventArgs(
                        Name,
                        false,
                        LoginEventType.Login
                    ));
                }
                throw new AccountException(AccountExceptionType.PASSWORD_INCORRECT);
            }
            else
            {
                IsAuthenticated = true;
                if (OnLogin != null)
                {
                    OnLogin(this, new LoginEventArgs(
                        Name,
                        true,
                        LoginEventType.Login
                    ));
                }
            }
        }

        // (5) Logout method
        public void Logout()
        {
            IsAuthenticated = false;
            // 이벤트가 null이 아닐 때만 Invoke
            if (OnLogin != null)
            {
                OnLogin(this, new LoginEventArgs(
                    Name,
                    true,
                    LoginEventType.Logout
                ));
            }
        }

        // (6) ToString method
        public override string ToString()
        {
            return $"{Name} [{Sin}] {(IsAuthenticated ? "authenticated" : "not authenticated")}";
        }
    }
}