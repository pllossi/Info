using System;

namespace TimeManagment
{
    public class Time
    {
        private int _minutes;
        private int _hours;

        public int Hours
        {
            get { return _hours; }
            private set
            {
                if (value < 0 || value > 23) throw new ArgumentOutOfRangeException($"{value} is not a valid hour value");
                _hours = value;
            }
        }

        public int Minutes
        {
            get { return _minutes; }
            private set
            {
                if (value < 0 || value > 59) throw new ArgumentOutOfRangeException($"{value} is not a valid minute value");
                _minutes = value;
            }
        }

        public Time(int hours, int minutes)
        {
            Hours = hours;
            Minutes = minutes;
        }

        public void AddHours(int hoursToAdd)
        {
            Hours = (Hours + hoursToAdd) % 24;
            if (Hours < 0) Hours += 24;
        }

        public void AddMinutes(int minutesToAdd)
        {
            int totalMinutes = Minutes + minutesToAdd;

            if (totalMinutes < 0)
            {
                int hoursToSubtract = (-totalMinutes + 59) / 60;
                AddHours(-hoursToSubtract);
                totalMinutes += hoursToSubtract * 60;
            }

            AddHours(totalMinutes / 60);
            Minutes = totalMinutes % 60;

            if (Minutes < 0)
            {
                Minutes += 60;
                AddHours(-1);
            }
        }

        public bool isAm()
        {
            if (_hours < 12) return true;
            return false;
        }

        //public string Periodo => Hours < 12 ? "AM" : "PM";
        public string Periodo
        {
            get { return Hours < 12 ? "AM" : "PM"; }
        }

        public override string ToString()
        {
            return $"{Hours:D2}:{Minutes:D2}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Time other)
            {
                return this.Hours == other.Hours && this.Minutes == other.Minutes;
            }
            return false;
        }
    }
}
