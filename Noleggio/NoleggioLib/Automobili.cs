using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioLib
{
    public class Automobili : Veicolo
    {
        public int postiAuto { get; private set; }
        public Automobili(string Targa, int CostoAlGiorno, int postiMacchina) : base(Targa, CostoAlGiorno) 
        {
            if (postiMacchina <= 0)
                throw new ArgumentException("I posti auto devono essere positivi.");
            postiAuto = postiMacchina;
        }
        public void InizioNoleggio(DateOnly inizio)
        {
            dataInizioNoleggio = inizio;
        }
        public override string ToString()
        {
            return $"Automobile: {targa}, Costo al giorno: {costoAlGiorno}€, Posti auto: {postiAuto}";
        }
    }
}
