using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioLib
{
    public class Moto : Veicolo
    {
        public string casco { get; private set; }
        public Moto(string Targa, int CostoAlGiorno, string Casco) : base(Targa, CostoAlGiorno)
        {
            if (string.IsNullOrEmpty(Casco))
                throw new ArgumentException("Il casco non può essere vuoto.");
            casco = Casco;
        }
        public void InizioNoleggio(DateOnly inizio)
        {
            dataInizioNoleggio = inizio;
        }

        public override string ToString()
        {
            return $"Moto: {targa}, Costo al giorno: {costoAlGiorno}€, Casco: {casco}";
        }
    }
}
