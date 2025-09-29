using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class VeterninaryVisit
    {
        private string _result;
        public string Result
        {
            get => _result;
            set
            {
                if (String.IsNullOrEmpty(_result))
                    throw new ArgumentException(nameof(_result));
                _result = value;
            }
        }
        private DateTime _visitDate;
        public DateTime VisitDate 
        { 
            get => _visitDate;
            private set => _visitDate = value;
        }
        private string _description;
        public string Description
        {
            get => _description;
            private set
            {
                if(value == "" || value == " ")
                    throw new ArgumentException(nameof(_description));
                _description = value;
            }
        }


        public VeterninaryVisit(DateTime visitDate, string description, Animal animal)
        {
            if (String.IsNullOrEmpty(description))
                throw new ArgumentException(nameof(description));
            VisitDate = visitDate;
            Description = description;
            Animal = animal ?? throw new ArgumentNullException(nameof(animal));
        }
    }
}
