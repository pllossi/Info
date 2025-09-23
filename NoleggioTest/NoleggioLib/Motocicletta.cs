using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggiLib
{
    public enum TipoCasco
    {
        JET,
        INTEGRALE,
        SEMI_INTEGRALE,
        CROSS
    }
    public class Motocicletta : Veicolo
    {
        public TipoCasco Casco { get; set; }
        public Motocicletta(double prezzoPerGiorno, string targa, TipoCasco casco) : base(prezzoPerGiorno, targa)
        {

            Casco = casco;
        }

        public override string Descrizione()
        {
            return $"Motocicletta - Targa: {Targa}, Prezzo per giorno: {PrezzoPerGiorno} EUR e ricevi in piu un casco di tipo {Casco}";
        }
    }
}
