using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainGesting
{
    public class Train
    {
        private int _trainNumber;
        public int TrainNumber
        {
            get
            {
                return _trainNumber;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Train Number is negative");
                }
                _trainNumber = value;
            }
        }
        private string _nameStartStation = string.Empty;
        private string _nameEndStation = string.Empty;
        private DateAndTime _staringTimeAspected = new DateAndTime(1, 1, 0, 0);
        private DateAndTime? _startingRealTime;
        private DateAndTime? _arrivingRealTime;
        private DateAndTime _arrivingTimeAspected = new DateAndTime(1, 1, 0, 0);
        public string NameStartStation
        {
            get
            {
                return _nameStartStation;
            }
            private set
            {
                if (value == "" || value == " ")
                {
                    throw new ArgumentException("start Station is blank or empty");
                }
                _nameStartStation = value.ToLower();
            }
        }
        public string NameEndStation
        {
            get
            {
                return _nameEndStation;
            }
            private set
            {
                if (value==""||value==" ")
                {
                    throw new ArgumentException("end Station is blank or empty");
                }
                _nameEndStation = value.ToLower();
            }
        }
        public DateAndTime StaringTimeAspected
        {
            get
            {
                return _staringTimeAspected;
            }
            private set
            {
                _staringTimeAspected = new DateAndTime(value.Day, value.Month, value.Hours, value.Minutes);
            }
        }
        public DateAndTime? StartingRealTime
        {
            get
            {
                return _startingRealTime;
            }
            private set
            {
                if (value != null)
                {
                    if (!value.isAfterThan(StaringTimeAspected))
                    {
                        throw new ArgumentException("The train started before when it was supposed to");
                    }
                    _startingRealTime = new DateAndTime(value.Day, value.Month, value.Hours, value.Minutes);
                }
                else
                    _startingRealTime = value;
            }
        }
        public DateAndTime? EndingRealTime
        {
            get
            {
                return _arrivingRealTime;
            }
            private set
            {
                if (value != null)
                {
                    if (StartingRealTime != null && !value.isAfterThan(StartingRealTime))
                    {
                        throw new ArgumentException("The train arrived before it started");
                    }
                    _arrivingRealTime = new DateAndTime(value.Day, value.Month, value.Hours, value.Minutes);
                }
                else _arrivingRealTime = value;
            }
        }
        public DateAndTime ArrivingTimeAspected
        {
            get
            {
                return _arrivingTimeAspected;
            }
            private set
            {
                if (!value.isAfterThan(StaringTimeAspected))
                {
                    throw new ArgumentException("Arriving time is before starting time");
                }
                _arrivingTimeAspected = new DateAndTime(value.Day, value.Month, value.Hours, value.Minutes);
            }
        }
        public Train(int trainNumber, string nameStartStation, string nameEndStation, DateAndTime staringTimeAspected, DateAndTime? startingRealTime, DateAndTime? arrivingRealTime, DateAndTime arrivingTimeAspected)
        {
            TrainNumber = trainNumber;
            NameStartStation = nameStartStation;
            NameEndStation = nameEndStation;
            StaringTimeAspected = staringTimeAspected;
            StartingRealTime = startingRealTime;
            EndingRealTime = arrivingRealTime;
            ArrivingTimeAspected = arrivingTimeAspected;
        }
        public void addRealStartingTime(DateAndTime startingRealTime)
        {
            StartingRealTime = startingRealTime;
        }
        public void addRealArrivingTime(DateAndTime arrivingRealTime)
        {
            EndingRealTime = arrivingRealTime;
        }
        public bool isLate()
        {
            if (StartingRealTime != null && StartingRealTime.isAfterThan(StaringTimeAspected))
            {
                return true;
            }
            else
            {
                if (StartingRealTime == null)
                {
                    throw new ArgumentNullException("The train has not started");
                }
                return false;
            }
        }
        public int Lateness()
        {
            try
            {
                if (isLate() && StartingRealTime != null)
                {
                    return StartingRealTime.Minutes - StaringTimeAspected.Minutes + (StartingRealTime.Hours - StaringTimeAspected.Hours) * 60;
                }
                return 0;
            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException($"{e}");
            }
        }
    }
}
