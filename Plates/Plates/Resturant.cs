using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plates
{
    public class Restaurant
    {
        public string Name { get; private set; }
        public Restaurant(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name), "name cant be null or empty");
            }

            Name = name;
        }
    }
}
