using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainGesting
{
    internal class Date
    {
        private int _day = 0;
        private int _year = 0;
        private int _month = 0;
        public int Year
        {
            get { return _year; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Illegal value exeption: Year is negative");
                }
                _year = value;
            }
        }
        public int Month
        {
            get { return _month; }
            private set
            {
                if (_month + value > 12)
                {
                    _month = _month + value - 12;
                }
                if (value < 0)
                {
                    throw new ArgumentException("Mese è negativo");
                }
                _month = value;
            }
        }
        public int Day
        {
            get { return _day; }
            private set
            {
                if ((_month == 1 || _month == 3 || _month == 5 || _month == 7 || _month == 8 || _month == 10 || _month == 12) && value + _day > 30)
                {
                    _month++;
                    _day = _day + value - 31;
                }
                else
                {
                    if (_month == 2 && isLeap() && _day + value > 28)
                    {
                        _month++;
                        _day = _day + value - 29;
                    }
                    else
                    {
                        if (_month == 2 && !isLeap() && _day + value > 27)
                        {
                            _month++;
                            _day = _day + value - 28;
                        }
                        else
                        {
                            if (_day + value > 29)
                            {
                                _month++;
                                _day = _day + value - 30;
                            }
                            else
                                _day = value;
                        }
                    }
                    if (value < 0)
                    {
                        throw new ArgumentException("Day è negativo");
                    }

                }
            }
        }
        public Date(int day, int year, int month)
        {
            Day = day;
            Year = year;
            Month = month;
        }

        public bool isLeap()
        {
            if (_year % 4 == 0 || (_year % 100 == 0 && _year % 400 == 0))
            {
                return true;
            }
            return false;
        }

        public void AddDays(int toAdd = 0)
        {
            if (toAdd < 0)
            {
                throw new ArgumentException("Day to add è negativo");
            }
            Day += toAdd;
        }
        public void AddMonth(int monthToAdd)
        {
            if (monthToAdd < 0)
            {
                throw new ArgumentException("Month to add is negative");
            }
            Month += monthToAdd;
        }
        public void AddYears(int yearsToAdd = 0)
        {
            if (yearsToAdd < 0)
                throw new ArgumentException("Years to add is negative");
            Year += yearsToAdd;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not Date) return false;
            Date objAsDate = obj as Date;
            if (_year == objAsDate.Year && _day == objAsDate.Day && _month == objAsDate.Month) return true;
            return false;
        }
        public override string ToString()
        {
            return $"{Day:D2}/{Month:D2}/{Year:D4}";
        }
    }
}

