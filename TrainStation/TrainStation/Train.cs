using Microsoft.VisualBasic;
namespace TrainStation
{
    public class Train
    {
        private int _trainNumber;
        private string _startStation, _endStation;
        private DateTime _expectedStart, _expectedEnd;
        private DateTime? _actualStart, _actualEnd;

        public int TrainNumber
        {
            get { return _trainNumber; }

            private set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Illegal train number");
                _trainNumber = value;
            }
        }

        public string StartStation
        {
            get { return _startStation; }

            private set
            {
                if (String.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("illegal start Station name");
                _startStation = value.ToLower();
            }
        }

        public string EndStation
        {
            get { return _endStation; }

            private set
            {
                if (String.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("illegal end Station name");
                _endStation = value.ToLower();
            }
        }

        public DateTime ExpectedStart
        {
            get { return _expectedStart; }

            private set
            {
                if (DateTime.Compare((DateTime)value,_expectedEnd)<=0)
                    throw new ArgumentOutOfRangeException("expected start is after the expected end");

                _expectedStart = value;
            }
        }

        public DateTime ExpectedEnd
        {
            get { return _expectedEnd; }

            private set
            {
                if (DateTime.Compare((DateTime)value,_expectedStart)<=0)
                    throw new ArgumentOutOfRangeException("expected end is before expected start");

                _expectedEnd = value;
            }
        }

        public DateTime? ActualStart
        {
            get { return _actualStart; }

            set
            {
                if (value != null )
                    if(DateTime.Compare((DateTime)value, _expectedStart) < 0)
                        throw new ArgumentOutOfRangeException("illegal start");
                _actualStart = value;
            }
        }

        public DateTime? ActualEnd
        {
            get { return _actualEnd; }

            private set
            {
                if (value is not null&& _actualStart is not null)
                {
                    if (DateTime.Compare((DateTime)value, (DateTime)_actualStart) < 0)
                        throw new ArgumentOutOfRangeException("illegal actual end");
                }
                _actualEnd = value;
            }
        }

        private bool _isDelayed;

        public bool IsDelayed
        {
            get
            {
                return _isDelayed;
            }
            private set
            {
                _isDelayed = delayInMinutes() > 0 ? true : false;
            }
        }

        private bool _isCanceled;

        public bool IsCancelled
        {
            get
            {
                return _isCanceled;
            }
            private set
            {

                _isCanceled = delayInMinutes() > 240 ? true : false;
            }
        }


        public Train(int trainNumber, string startStation, string endStation, DateTime exStart, DateTime exEnd, DateTime? acStart = null, DateTime? acEnd = null)
        {
            TrainNumber = trainNumber;
            StartStation = startStation;
            EndStation = endStation;
            ExpectedStart = exStart;
            ExpectedEnd = exEnd;
            ActualStart = acStart;
            ActualEnd = acEnd;

        }

        public int delayInMinutes()
        {
            if (ActualEnd == null)
                return 0;

            TimeSpan delay = ActualEnd.Value - ExpectedEnd;
            return (int)delay.TotalMinutes;
        }


        public int ActualDurationInMinutes
        {
            get
            {
                if (ActualEnd == null || ActualStart == null) { throw new InvalidOperationException(); }
                TimeSpan duration = ActualEnd.Value - ActualStart.Value;
                return (int)duration.TotalMinutes;
            }

        }

        public int ExpectedDuration
        {
            get
            {
                TimeSpan duration = ExpectedEnd - ExpectedStart;
                return (int)duration.TotalMinutes;
            }
        }
    }
}
