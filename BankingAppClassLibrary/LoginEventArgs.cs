using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppClassLibrary
{
    // Studnet 1
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
    }
}
