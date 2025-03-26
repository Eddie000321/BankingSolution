using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppClassLibrary
{
    public class Person
    {
        private readonly string password;
        public event LoginEventHandler OnLogin;

        public string Sin { get; }
        public string Name { get; }
        public bool IsAuthenticated { get; private set; }

        public Person(string name, string sin)
        {
            Name = name;
            Sin = sin;
            password = sin.Substring(0, Math.Min(3, sin.Length));
            IsAuthenticated = false;
        }

        public void Login(string pwd)
        {
            if (pwd != password)
            {
                IsAuthenticated = false;
                OnLogin?.Invoke(this, new LoginEventArgs(Name, false, LoginEventType.Login));
                throw new AccountException(AccountExceptionType.PASSWORD_INCORRECT);
            }

            IsAuthenticated = true;
            OnLogin?.Invoke(this, new LoginEventArgs(Name, true, LoginEventType.Login));
        }

        public void Logout()
        {
            IsAuthenticated = false;
            OnLogin?.Invoke(this, new LoginEventArgs(Name, true, LoginEventType.Logout));
        }

        public override string ToString()
        {
            return $"{Name} [{Sin}] {(IsAuthenticated ? \"authenticated\" : \"not authenticated\")}";
        }
    }
}
