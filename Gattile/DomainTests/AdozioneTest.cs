using Domain.Entities;
using Domain.ValueObjects;

namespace DomainTests;

[TestClass]
public class AdozioneTest
{
    [TestMethod]
    public void Costruttore_ValoriValidi_OttengoIstanza()
    {
        var telefono = new PhoneNumber("3331234567");
        var email = new Email("test@email.com");

        var adottante = new Adottante("Mario", "Rossi", telefono, email);

        Assert.AreEqual("Mario", adottante.Name);
        Assert.AreEqual("Rossi", adottante.Surname);
        Assert.AreEqual(telefono, adottante.Telefono);
        Assert.AreEqual(email, adottante.Email);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Costruttore_NomeVuoto_LanciaArgumentException()
    {
        var telefono = new PhoneNumber("3331234567");
        var email = new Email("test@email.com");

        var _ = new Adottante("", "Rossi", telefono, email);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Costruttore_CognomeVuoto_LanciaArgumentException()
    {
        var telefono = new PhoneNumber("3331234567");
        var email = new Email("test@email.com");

        var _ = new Adottante("Mario", "", telefono, email);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Costruttore_NumeroENullEmailNull_LanciaArgumentNullException()
    {
        var _ = new Adottante("Mario", "Rossi", null, null);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Costruttore_NumeroNull_LanciaArgumentNullException()
    {
        var email = new Email("test@email.com");

        var _ = new Adottante("Mario", "Rossi", null, email);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Costruttore_EmailNull_LanciaArgumentNullException()
    {
        var telefono = new PhoneNumber("3331234567");

        var _ = new Adottante("Mario", "Rossi", telefono, null);
    }

    [TestMethod]
    public void ToString_AdottanteValido_RitornaNomeCognome()
    {
        var telefono = new PhoneNumber("3331234567");
        var email = new Email("test@email.com");
        var adottante = new Adottante("Mario", "Rossi", telefono, email);

        Assert.AreEqual("Mario Rossi", adottante.ToString());
    }
}
