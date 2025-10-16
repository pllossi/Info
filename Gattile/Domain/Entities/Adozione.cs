using Domain.Entities;

public class Adozione
{
    public Adozione(Adottante adottante, Gatto gatto, DateTime dataAdozione)
    {
        Adottante = adottante;
        Gatto = gatto;
        DataAdozione = dataAdozione;
    }

    public Gatto Gatto 
    { 
        get => _gatto;
        private set
        {
            _gatto = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
    private Gatto _gatto;
    public Adottante Adottante 
    { 
        get => _adottante;
        private set
        {
            _adottante = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
    private Adottante _adottante;
    public DateTime DataAdozione { get; private set; }
}
