using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainGesting
{
    public class Ticket
    {
        private Train? _trainReferred;
        public Train? TrainReferred
        {
            get
            {
                return _trainReferred;
            }
            private set
            {
                if (value != null)
                {
                    throw new ArgumentNullException("Train is null");
                }
                _trainReferred = value;
            }
        }
        private bool _isConvalidated;
        public bool IsConvalidated
        {
            get
            {
                if (TimeOfConvalidation.Hours > 3 && TimeOfConvalidation.Minutes>1)
                {
                    _isConvalidated = false;
                    return false;
                }
                return IsConvalidated;
            }
            private set
            {
                _isConvalidated = value;
            }
        }
        private DateAndTime? _timeOfConvalidation;
        public DateAndTime? TimeOfConvalidation
            {
            get
            {
                return _timeOfConvalidation;
            }
            private set
            {
                _timeOfConvalidation = value;
            }
        }
        public Ticket(DateAndTime? timeOfConvalidation, bool isConvalidated =  false,Train trainReferred = null)
        {
            TimeOfConvalidation = timeOfConvalidation;
            IsConvalidated = isConvalidated;
            TrainReferred = trainReferred;
        }
        public void Convalidate(DateAndTime timeOfConvalidation)
        {
            if (IsConvalidated)
            {
                throw new InvalidOperationException("Ticket is already convalidated");
            }
            TimeOfConvalidation = timeOfConvalidation;
            IsConvalidated = true;
        }
        public override bool Equals(object? obj)
        {
           if(obj == null)
            {
                throw new ArgumentNullException("Object is null");
            }
           if (obj is Ticket)
            {

                Ticket ticket = (Ticket)obj;
                return TrainReferred == ticket.TrainReferred && IsConvalidated == ticket.IsConvalidated && TimeOfConvalidation == ticket.TimeOfConvalidation;
            }
            return false;
        }
    }
}
