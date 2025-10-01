using Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Entities
{
    public class Dog : Animal
    {
        private string? _favouriteChewing;
        public string? FavouriteChewing
        {
            get { return _favouriteChewing; }
            set
            {                
                if (value is not null && string.IsNullOrEmpty(value)) throw new ArgumentException("is empty");
                _favouriteChewing = value;
            }
        }

        public Dog(string name, List<VeterinaryVisit>? visits = null)
             : base(name, visits) { }

        public Dog(string name, Birthdate birthdate, string breed, string favouriteChewing, List<VeterinaryVisit>? visits = null)
            : base(name, birthdate, breed, visits) 
        {
            FavouriteChewing = favouriteChewing;
        }
    }
}
