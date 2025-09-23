using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggiLib
{
    public class Bicicletta : Veicolo
    {
        public Bicicletta(double prezzoPerGiorno, string targa) : base(prezzoPerGiorno, targa, 10,7)
        {

        }

        public override string Descrizione()
        {
            return $"Bicicletta - Targa: {Targa}, Prezzo per giorno: {PrezzoPerGiorno} EUR ";
        }
    }
}
