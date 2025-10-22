using Domain.Entities;
using Domain.ValueObjects;

namespace DomainTests.Entities;

[TestClass]
public class AdopterTest
{
    [TestMethod]
    public void Constructor_ValidValues_ReturnsInstance()
    {
        var phone = new PhoneNumber("3331234567");
        var email = new Email("test@email.com");
        var taxId = new TaxId("RSSMRA80A01H501U");

        var adopter = new Adopter("Mario", "Rossi", phone, email, taxId);

        Assert.AreEqual("Mario", adopter.Name);
        Assert.AreEqual("Rossi", adopter.Surname);
        Assert.AreEqual(phone, adopter.Phone);
        Assert.AreEqual(email, adopter.Email);
        Assert.AreEqual(taxId, adopter.TaxId);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Constructor_EmptyName_ThrowsArgumentException()
    {
        var phone = new PhoneNumber("3331234567");
        var email = new Email("test@email.com");
        var taxId = new TaxId("RSSMRA80A01H501U");

        var _ = new Adopter("", "Rossi", phone, email, taxId);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Constructor_EmptySurname_ThrowsArgumentException()
    {
        var phone = new PhoneNumber("3331234567");
        var email = new Email("test@email.com");
        var taxId = new TaxId("RSSMRA80A01H501U");

        var _ = new Adopter("Mario", "", phone, email, taxId);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Constructor_NullPhoneAndNullEmail_ThrowsArgumentNullException()
    {
        var taxId = new TaxId("RSSMRA80A01H501U");
        var _ = new Adopter("Mario", "Rossi", null, null, taxId);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Constructor_NullPhone_ThrowsArgumentNullException()
    {
        var email = new Email("test@email.com");
        var taxId = new TaxId("RSSMRA80A01H501U");

        var _ = new Adopter("Mario", "Rossi", null, email, taxId);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Constructor_NullEmail_ThrowsArgumentNullException()
    {
        var phone = new PhoneNumber("3331234567");
        var taxId = new TaxId("RSSMRA80A01H501U");

        var _ = new Adopter("Mario", "Rossi", phone, null, taxId);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Constructor_NullTaxId_ThrowsArgumentNullException()
    {
        var phone = new PhoneNumber("3331234567");
        var email = new Email("test@email.com");

        var _ = new Adopter("Mario", "Rossi", phone, email, null);
    }

    [TestMethod]
    public void ToString_ValidAdopter_ReturnsNameSurname()
    {
        var phone = new PhoneNumber("3331234567");
        var email = new Email("test@email.com");
        var taxId = new TaxId("RSSMRA80A01H501U");
        var adopter = new Adopter("Mario", "Rossi", phone, email, taxId);

        Assert.AreEqual("Mario Rossi", adopter.ToString());
    }
}
