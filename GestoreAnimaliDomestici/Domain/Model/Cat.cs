using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Cat : Animal
    {
        public Cat(string name, string favouriteGame) : base(name, favouriteGame)
        {
        }
    }
}
