using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   

namespace Domain.Model
{
    public class Veterinary
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
        private EmailAddressAttribute _email;
        public EmailAddressAttribute Email
        {
            get => _email;
            private set
            {
                if (!EmailAddressAttribute.IsValid(value))
                    throw new ArgumentNullException(nameof(_email));
                _email = value;
            }
        }
        private PhoneAttribute _phone;
        public PhoneAttribute Phone
        {
            get => _phone;
            private set
            {
                if (!PhoneAttribute.IsValid(value))
                    throw new ArgumentNullException(nameof(_phone));
                _phone = value;
            }
        }

    }
}