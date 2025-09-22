namespace NoleggioLib
{
    public class Veicolo
    {
        public string targa { get; private set; }
        protected int costoAlGiorno;
        protected DateOnly dataInizioNoleggio;
        
        public Veicolo(string Targa, int CostoAlGiorno)
        {
            if(string.IsNullOrEmpty(Targa))
                throw new ArgumentException("La targa non può essere vuota.");
            targa = Targa;
            if (CostoAlGiorno <= 0)
                throw new ArgumentException("Il costo al giorno deve essere positivo.");
            costoAlGiorno = CostoAlGiorno;
        }

        public virtual int CalcolaCosto(DateOnly dataFineNoleggio)
        {
            int giorni = dataFineNoleggio.DayNumber - dataInizioNoleggio.DayNumber + 1;
            return costoAlGiorno * giorni;
        }
        
    }
}
