using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ValueObjects
{
    public record FullName
    {
        public string First { get; }
        public string Last { get; }

        public FullName(string first, string last)
        {
            if (string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(last))
                throw new ArgumentException("Nome e cognome obbligatori");

            First = first;
            Last = last;
        }

        public override string ToString() => $"{First} {Last}";

        /*
         * I record sono tipi valore o tipi riferimento immutabili progettati per la gestione 
         * dei dati, il compilatore C# crea automaticamente metodi che rendono i record 
         * confrontabili in base ai loro valori. 
         * Quindi due Fullname saranno uguali quando avrannostesso nome e stesso cognome
         */
    }
}
