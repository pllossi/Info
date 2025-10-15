using GattileLib;

public class Adozione
{
    public Adozione(Adottante adottante, Gatto gatto, DateTime dataAdozione)
    {
        Adottante = adottante;
        Gatto = gatto;
        DataAdozione = dataAdozione;
    }

    public Gatto Gatto { get; set; }
    public Adottante Adottante { get; set; }
    public DateTime DataAdozione { get; set; }
}
