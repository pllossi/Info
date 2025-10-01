using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ValueObjects
{
    public record Email
    {
        public string Value { get; }

        /// <summary>
        /// email accettabile se ha il simobolo @ dopo di esso almeno un 
        /// carattere poi il punto e almemo 2 caratteri
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentException"></exception>
        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !value.Contains("@") || !value.Contains("."))
                throw new ArgumentException("Email non valida manca @ o .");
            //controllo che ci sia 1 sola chiocciola                        
            //controllo che l'ultimo punto sia dopo la chiocciola e che dopo di esso ci siano
            //almeno 2 caratteri
            int lastPositionAt = value.LastIndexOf('@');
            int firstPositionAt = value.IndexOf('@');
            int positionPoint = value.LastIndexOf('.');
            if (!(lastPositionAt == firstPositionAt && positionPoint > lastPositionAt + 1 && value.Length >= positionPoint + 2))
                throw new ArgumentException("Email non valida il . è nella posizione sbagliata");

            Value = value;
        }

        public override string ToString() => Value;
    }
}
