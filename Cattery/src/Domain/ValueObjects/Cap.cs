using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public record Cap
    {
        public string Value { get; }
        /// <summary>
        /// CAP accettabile se è lungo 5 caratteri numerici
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentException"></exception>
        public Cap(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length != 5 || !value.All(char.IsDigit))
                throw new ArgumentException("CAP non valido deve essere lungo 5 caratteri numerici.");
            Value = value;
        }
        public override string ToString() => Value;
    }
}
