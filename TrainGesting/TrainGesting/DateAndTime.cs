using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainGesting
{
    public class DateAndTime
    {
        private Date Date;
        private Time Time; 
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
        public int Hours
        {
            get { return Time.Hours; }
        }
        public int Minutes
        {
            get { return Time.Minutes; }
        }
        public int Day
        {
            get { return Date.Day; }
        }
        public int Month
        {
            get { return Date.Month; }
        }
        public int Year
        {
            get { return Date.Year; }
        }
        public bool isAfterThan(DateAndTime dateAndTime)
        {
            if ((Day > dateAndTime.Date.Day && Month == dateAndTime.Month && Year == dateAndTime.Year) || (Month > dateAndTime.Month && Year == dateAndTime.Year) || Year > dateAndTime.Year || (Minutes > dateAndTime.Minutes && Hours == dateAndTime.Minutes && Day > dateAndTime.Date.Day && Month == dateAndTime.Month && Year == dateAndTime.Year) || (Hours > dateAndTime.Hours && Day > dateAndTime.Date.Day && Month == dateAndTime.Month && Year == dateAndTime.Year))
            {
                return true;
            }
            return false;
        }
        public bool isTheSameMoment(DateAndTime dateAndTime)
        {
            if (Day == dateAndTime.Day && Month == dateAndTime.Month && Year == dateAndTime.Year && Hours == dateAndTime.Hours && Minutes == dateAndTime.Minutes)
            {
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return $"{Date.ToString()},{Time.ToString()}";
        }

    }
}
