using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioLib
{
    public class Bicicletta : Veicolo
    {
        public TipoCasco Casco { get; private set; }
        public Bicicletta(string Targa, int CostoAlGiorno, string casco) : base(Targa, CostoAlGiorno) 
        {
            if (casco == null|| (casco.ToLower() != "integrale" && casco.ToLower() != "jet" && casco.ToLower() !="semi integrale"))
                throw new ArgumentNullException("Casco errato");
            casco = casco.ToLower();
            switch (casco)
            {
                case ("jet"): Casco = TipoCasco.Jet; break;
                case ("integrale"): Casco=TipoCasco.Integrale; break;
                default: Casco= TipoCasco.Semi_Integrale; break;
            }
        }
        public void InizioNoleggio(DateOnly inizio)
        {
            dataInizioNoleggio = inizio;
        }
        public override int CalcolaCosto(DateOnly dataFineNoleggio)
        {
            int giorni = dataFineNoleggio.DayNumber - dataInizioNoleggio.DayNumber + 1;
            if (giorni > 7)
                return (costoAlGiorno * giorni) - (costoAlGiorno * giorni / 10);
            return (costoAlGiorno * giorni);
        }
        public override string ToString()
        {
            return $"Bicicletta: {targa}, Costo al giorno: {costoAlGiorno}€, Tipo Casco {Casco}";
        }
    }
}
