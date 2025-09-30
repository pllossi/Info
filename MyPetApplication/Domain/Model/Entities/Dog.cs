using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Entities
{
    public class Dog : Animal // codice di Boschi
    {
        private string _masticativeToy;
        public string MasticativeToy
        {
            get => _masticativeToy;
            private set
            {
                if (String.IsNullOrEmpty(_masticativeToy))
                    throw new ArgumentException(nameof(_masticativeToy));
                _masticativeToy = value;
            }
        }
        public Dog(string name, string favouriteGame, string masticativeToy, string favouriteFood): base(name, null, favouriteFood, favouriteGame)
        {
            MasticativeToy = masticativeToy;
        }
    }
}
