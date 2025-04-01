using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppClassLibrary
{
    public static class Util
    {
        // 난수 발생용 Random
        private static Random random = new Random();

        // 현재 시각을 나타내는 DayTime (2025-03-22 10:15 기준으로 가정)
        // 과제에서 제시된 방법대로 계산한 minutes 값 (2년, 2개월, 21일, 10시간, 15분 등 누적)
        private static DayTime currentTime = new DayTime(1154055);

        // Now 프로퍼티: 호출될 때마다 currentTime을 조금씩 증가시켜 시간 흐름을 시뮬레이션
        public static DayTime Now
        {
            get
            {
                int increment = random.Next(100); // 0~99분
                currentTime = currentTime + increment;
                return currentTime;
            }
        }
    }
}
