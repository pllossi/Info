using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ValueObjects
{
    public record Address
    {
        public string Street { get; }
        public string City { get; }
        public string ZipCode { get; }

        public Address(string street, string city, string zipCode)
        {
            if (string.IsNullOrWhiteSpace(street) || string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("Indirizzo non valido");

            Street = street;
            City = city;
            ZipCode = zipCode;
        }

        public override string ToString() => $"{Street}, {ZipCode} {City}";
    }
}
