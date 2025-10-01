using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Entities
{
    public enum VisitResults
    {
        POSITIVE,
        NEGATIVE,
        WAITING,
        CHECK_NOTES
    }
    public class VeterinaryVisit
    {
        public Animal Animal { get; private set; }
        public Veterinary Veterinary { get; private set; }
        public DateTime Date { get; private set; }
        public string? Notes { get; private set; }
        public VisitResults Results { get; private set; }

        public VeterinaryVisit(Animal animal, Veterinary veterinary, DateTime date, VisitResults result, string? notes = null)
        {
            Animal = animal;
            Veterinary = veterinary;
            Date = date;
            Results = result;
            Notes = notes;
        }

        public override string ToString() =>
            $"{Date.ToShortDateString()} - {Animal.Name} visited by {Veterinary.Name}";
    }
}
