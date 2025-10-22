using Domain.Entities;
using Domain.ValueObjects;

namespace DomainTests.Entities;

[TestClass]
public class AdottanteTest
{
    [TestMethod]
    public void Costruttore_ValoriValidi_OttengoIstanza()
    {
        var telefono = new PhoneNumber("3331234567");
        var email = new Email("test@email.com");
        var codiceFiscale = new TaxId("RSSMRA80A01H501U");

        var adottante = new Adottante("Mario", "Rossi", telefono, email, codiceFiscale);

        Assert.AreEqual("Mario", adottante.Name);
        Assert.AreEqual("Rossi", adottante.Surname);
        Assert.AreEqual(telefono, adottante.Telefono);
        Assert.AreEqual(email, adottante.Email);
        Assert.AreEqual(codiceFiscale, adottante.CodiceFiscale);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Costruttore_NomeVuoto_LanciaArgumentException()
    {
        var telefono = new PhoneNumber("3331234567");
        var email = new Email("test@email.com");
        var codiceFiscale = new TaxId("RSSMRA80A01H501U");

        var _ = new Adottante("", "Rossi", telefono, email, codiceFiscale);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Costruttore_CognomeVuoto_LanciaArgumentException()
    {
        var telefono = new PhoneNumber("3331234567");
        var email = new Email("test@email.com");
        var codiceFiscale = new TaxId("RSSMRA80A01H501U");

        var _ = new Adottante("Mario", "", telefono, email, codiceFiscale);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Costruttore_NumeroENullEmailNull_LanciaArgumentNullException()
    {
        var codiceFiscale = new TaxId("RSSMRA80A01H501U");
        var _ = new Adottante("Mario", "Rossi", null, null, codiceFiscale);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Costruttore_NumeroNull_LanciaArgumentNullException()
    {
        var email = new Email("test@email.com");
        var codiceFiscale = new TaxId("RSSMRA80A01H501U");

        var _ = new Adottante("Mario", "Rossi", null, email, codiceFiscale);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Costruttore_EmailNull_LanciaArgumentNullException()
    {
        var telefono = new PhoneNumber("3331234567");
        var codiceFiscale = new TaxId("RSSMRA80A01H501U");

        var _ = new Adottante("Mario", "Rossi", telefono, null, codiceFiscale);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Costruttore_CodiceFiscaleNull_LanciaArgumentNullException()
    {
        var telefono = new PhoneNumber("3331234567");
        var email = new Email("test@email.com");

        var _ = new Adottante("Mario", "Rossi", telefono, email, null);
    }

    [TestMethod]
    public void ToString_AdottanteValido_RitornaNomeCognome()
    {
        var telefono = new PhoneNumber("3331234567");
        var email = new Email("test@email.com");
        var codiceFiscale = new TaxId("RSSMRA80A01H501U");
        var adottante = new Adottante("Mario", "Rossi", telefono, email, codiceFiscale);

        Assert.AreEqual("Mario Rossi", adottante.ToString());
    }
}
