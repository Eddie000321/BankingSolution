using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppClassLibrary
{
    public class DayTime
    {
        private long minutes;

        // Constructor
        public DayTime(long minutes)
        {
            this.minutes = minutes;
        }

        // Overloaded + operator
        public static DayTime operator +(DayTime lhs, int minutes)
        {
            return new DayTime(lhs.minutes + minutes);
        }

        // Override ToString method
        public override string ToString()
        {
            long totalMinutes = minutes;
            int year = 2023;
            int month = 1;
            int day = 1;
            int hour = 0;
            int minute = 0;

            while (totalMinutes >= 518_400) // One year
            {
                totalMinutes -= 518_400;
                year++;
            }

            while (totalMinutes >= 43_200) // One month
            {
                totalMinutes -= 43_200;
                month++;
            }

            while (totalMinutes >= 1_440) // One day
            {
                totalMinutes -= 1_440;
                day++;
            }

            while (totalMinutes >= 60) // One hour
            {
                totalMinutes -= 60;
                hour++;
            }

            minute = (int)totalMinutes;

            return $"{year:D4}-{month:D2}-{day:D2} {hour:D2}:{minute:D2}";
        }
    }
}
