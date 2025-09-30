using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;  
using Domain.Model.ValueObjects;

namespace Domain.Model.Entities
{
    public class Veterinary // codice di Boschi
    {
        private string _name;
        public string Name
        {
            get => _name;
            private set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(_name));
                _name = value;
            }
        }
        private Email _email;
        public Email Email
        {
            get => _email;
            private set
            {
              _email = value;
            }
        }
        private Phone _phone;
        public Phone Phone
        {
            get => _phone;
            private set
            {
                _phone = value;
            }
        }

    }
}