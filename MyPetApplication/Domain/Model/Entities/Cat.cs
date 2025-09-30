using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Entities
{
    public class Cat : Animal // codice di Boschi
    {
        public Cat(string name, string favouriteGame, string favouriteFood) : base(name,null,favouriteFood,favouriteGame)
        {
        }
    }
}
