using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioLib
{
    public class Bicicletta : Veicolo
    {
        public Bicicletta(string Targa, int CostoAlGiorno) : base(Targa, CostoAlGiorno) { }
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
            return $"Bicicletta: {targa}, Costo al giorno: {costoAlGiorno}€";
        }
    }
}
