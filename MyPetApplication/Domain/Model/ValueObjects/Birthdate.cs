using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ValueObjects
{
    public record Birthdate
    {
        public DateOnly Value { get; }

        /// <summary>
        /// la data di nascita è accettabile se è nel passato
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentException"></exception>
        public Birthdate(DateOnly value)
        {
            if(value >= DateOnly.FromDateTime(DateTime.Now))
                throw new ArgumentOutOfRangeException("birthdate invalid");
            Value = value;
        }

        public override string ToString() => Value.ToShortDateString();
    }
}
