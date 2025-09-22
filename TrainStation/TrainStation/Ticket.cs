using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStation;

namespace TrainStation
{
    public class Ticket
    {
        private int _trainNumber;

        public int TicketTrainNumber
        {
            get
            {
                return _trainNumber;
            }

            private set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("illegal ticket number");
                _trainNumber = value;
            }
        }

        public DateTime? ValidateTime
        {
            get;
            private set;
        }

        public Ticket(int trainNumber, DateTime? validateTime = null)
        {
            TicketTrainNumber = trainNumber;
            ValidateTime = validateTime;
        }

        public void ValidateTicket(DateTime time)
        {
            if (ValidateTime == null)
            {
                ValidateTime = time;
            }
            else
            {
                throw new InvalidOperationException("biglietto già convalidato");
            }
        }

        /// <summary>
        /// il biglietto è valido se non è convalidato o è convalidato e non sono trascorse 3 ore
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public bool IsTicketStillValid(DateTime time)
        {
            if (ValidateTime == null) return true;
            if (DateTime.Compare(time,(DateTime)ValidateTime)<0) return true;
            TimeSpan diffTime = time.Subtract((DateTime)ValidateTime);
            if (diffTime.TotalMinutes<180) return true;
            return false;
        }

        public bool IsTicketForATrain(int trainNumber)
        {
            return TicketTrainNumber == trainNumber;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Ticket)) return false;

            Ticket ticket = (Ticket)obj;

            if (TicketTrainNumber == ticket.TicketTrainNumber && ValidateTime.Equals(ticket.ValidateTime)) return true;
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(TicketTrainNumber, ValidateTime);
        }
    }
}
