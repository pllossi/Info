using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GattileLib
{
    public class Adottante
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public override string ToString() => $"{Nome} {Cognome}";
    }
}