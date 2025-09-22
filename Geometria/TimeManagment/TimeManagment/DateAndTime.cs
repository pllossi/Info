using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManagment
{
    public class DateAndTime
    {
        public Date Date;
        public Time Time;
        public DateAndTime(int day, int month, int year, int hours = 00, int min = 00)
        {
            Date = new Date(day, year, month);
            Time = new Time(hours, min);
        }

        public void AddYears(int years)
        {
            Date.AddYears(years);
        }
        public void AddMonths(int months)
        {
            Date.AddMonth(months);
        }
        public void AddDays(int days)
        {
            Date.AddDays(days);
        }
        public void AddHours(int hours)
        {
            Time.AddHours(hours);
        }
        public void AddMinutes(int minutes)
        {
            Time.AddMinutes(minutes);
        }
        public override string ToString()
        {
            return $"{Date.ToString()},{Time.ToString()}";
        }

    }
}
