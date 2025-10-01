using Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Model.Entities
{
    public class Cat : Animal
    {
        public Cat(string name, List<VeterinaryVisit>? visits = null)
             : base(name,visits){ }

        public Cat (string name, Birthdate birthdate, string breed, List<VeterinaryVisit>? visits = null)
            : base(name, birthdate,breed, visits){ }
    }
}
