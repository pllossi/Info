using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class VeterninaryVisit
    {
        public DateTime VisitDate { get; private set; }
        public string Description { get; private set; }

        public VeterninaryVisit(DateTime visitDate, string description)
        {
            if (String.IsNullOrEmpty(description))
                throw new ArgumentException(nameof(description));
            VisitDate = visitDate;
            Description = description;
        }
    }
}
