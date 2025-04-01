using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppClassLibrary
{
    public class AccountException : Exception
    {
        // 유일한 생성자: AccountExceptionType 을 인자로 받는다
        public AccountException(AccountExceptionType reason)
            : base(reason.ToString()) // Exception 클래스의 메시지로 reason.ToString() 사용
        {
            // 추가 로직 필요 없다면 본문은 비어 있어도 됨
        }
    }
}
