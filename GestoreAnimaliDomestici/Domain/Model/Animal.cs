using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public abstract class Animal
    {
        private string _name;
        public string Name {
            get => _name; 
            private set
            {
                if (String.IsNullOrEmpty(_name))
                    throw new ArgumentNullException(nameof(_name));
                _name = value;
            }
        }
        public VeterninaryVisit[] veterninaryVisits { get; private set; }
        private string _favouriteGame;
        public string FavouriteGame
        {
            get => _favouriteGame;
            set
            {
                if (String.IsNullOrEmpty(_favouriteGame))
                    throw new ArgumentException(nameof(_favouriteGame));
                _favouriteGame = value;
            }
        }

    }
}
