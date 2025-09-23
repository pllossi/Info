using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggiLib
{
    public class Noleggio
    {
        private Veicolo _veicolo;
        public Veicolo Veicolo
        {
            get => _veicolo;
            private set
            {
                if (value is null) { throw new ArgumentNullException("il veicolo non può essere nullo"); }
                _veicolo = value;
            }
        }
        private int _numeroGiorni;
        public int NumeroGiorni
        {
            get => _numeroGiorni;
            set
            {
                if (value <= 0) { throw new ArgumentOutOfRangeException("numero giorni non accettabile"); }
                _numeroGiorni = value;
            }
        }

        public Noleggio(Veicolo veicolo, int numeroGiorni)
        {
            Veicolo = veicolo;
            NumeroGiorni = numeroGiorni;
        }

        public double CalcolaCostoNoleggio()
        {
            double costo =  Veicolo.PrezzoPerGiorno * NumeroGiorni;
            if(Veicolo.PercentualeSconto>0 && NumeroGiorni >= Veicolo.GiorniPerSconto)
            {
                costo -= (costo * Veicolo.PercentualeSconto)/100; 
            }

            return costo;
        }
    }
}
