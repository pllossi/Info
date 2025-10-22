using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public record TaxId
    {
        public string Value { get; }
        /// <summary>
        /// Codice Fiscale accettabile se è lungo 16 caratteri
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentException"></exception>
        public TaxId(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length != 16)
                throw new ArgumentException("Codice Fiscale non valido deve essere lungo 16 caratteri.");
            Value = value;
        }
        public override string ToString() => Value;
    }
}
