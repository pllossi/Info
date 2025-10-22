namespace Domain.Entities
{
    public class Adozione
    {
        private Gatto _gatto;
        private Adottante _adottante;
        public Gatto Gatto
        {
            get => _gatto;
            private set
            {
                _gatto = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

        public Adottante Adottante
        {
            get => _adottante;
            private set
            {
                _adottante = value ?? throw new ArgumentNullException(nameof(value));
            }
        }
        public DateTime DataAdozione { get; private set; }

        public Adozione(Adottante adottante, Gatto gatto, DateTime dataAdozione)
        {
            Adottante = adottante;
            Gatto = gatto;
            DataAdozione = dataAdozione;
        }

        
    }
}
