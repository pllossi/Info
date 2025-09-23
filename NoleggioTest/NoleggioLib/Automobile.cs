namespace NoleggiLib
{
    public class Automobile : Veicolo // Cambiato da 'internal' a 'public'
    {
        private int _posti;
        public int Posti // Già public, non serve modificare
        {
            get => _posti;
            set
            {
                if (value < 1) throw new ArgumentOutOfRangeException("numero posti non acccettabile");
                _posti = value;
            }
        }
        public Automobile(double prezzoPerGiorno, string targa, int posti) : base(prezzoPerGiorno, targa)
        {
            Posti = posti;
        }

        public override string Descrizione()
        {
            return $"Automobile - Targa: {Targa}, Prezzo per giorno: {PrezzoPerGiorno} EUR e ha {Posti} posti.";
        }
    }
}
