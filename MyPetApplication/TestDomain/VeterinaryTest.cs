using Domain.Model.Entities;
using Domain.Model.ValueObjects;

namespace TestDomain;

[TestClass]
public class TestVeterinary
{
    [TestMethod]
    public void Veterinary_Constructor_SetsProperties()
    {
        var name = new FullName("Mario", "Rossi");
        var email = new Email("mario.rossi@vet.com");
        var phone = new PhoneNumber("39123456789");
        var specialization = "Cani";
        var vet = new Veterinary(name, email, phone, specialization);
        Assert.AreEqual(name, vet.Name);
        Assert.AreEqual(email, vet.Email);
        Assert.AreEqual(phone, vet.Phone);
        Assert.AreEqual(specialization, vet.Specialization);
    }

    [TestMethod]
    public void Veterinary_Constructor_EmptySpecialization_DefaultsToGeneral()
    {
        var name = new FullName("Anna", "Bianchi");
        var email = new Email("anna.bianchi@vet.com");
        var phone = new PhoneNumber("39123456780");
        var vet = new Veterinary(name, email, phone, "");
        Assert.AreEqual("General", vet.Specialization);
    }

    [TestMethod]
    public void Veterinary_Constructor_NullSpecialization_DefaultsToGeneral()
    {
        var name = new FullName("Luca", "Verdi");
        var email = new Email("luca.verdi@vet.com");
        var phone = new PhoneNumber("39123456781");
        var vet = new Veterinary(name, email, phone, null);
        Assert.AreEqual("General", vet.Specialization);
    }

    [TestMethod]
    public void Veterinary_ToString_ReturnsExpectedFormat()
    {
        var name = new FullName("Mario", "Rossi");
        var email = new Email("mario.rossi@vet.com");
        var phone = new PhoneNumber("39123456789");
        var specialization = "Cani";
        var vet = new Veterinary(name, email, phone, specialization);
        var expected = $"{name} ({specialization}) - {email}";
        Assert.AreEqual(expected, vet.ToString());
    }

    [TestMethod]
    public void Veterinary_Equals_SameFullName_ReturnsTrue()
    {
        var name = new FullName("Mario", "Rossi");
        var email1 = new Email("mario.rossi@vet.com");
        var email2 = new Email("mario2.rossi@vet.com");
        var phone1 = new PhoneNumber("39123456789");
        var phone2 = new PhoneNumber("39123456780");
        var vet1 = new Veterinary(name, email1, phone1, "Cani");
        var vet2 = new Veterinary(name, email2, phone2, "Gatti");
        Assert.IsTrue(vet1.Equals(vet2));
        Assert.AreEqual(vet1.GetHashCode(), vet2.GetHashCode());
    }

    [TestMethod]
    public void Veterinary_Equals_DifferentFullName_ReturnsFalse()
    {
        var name1 = new FullName("Mario", "Rossi");
        var name2 = new FullName("Anna", "Bianchi");
        var email = new Email("test@vet.com");
        var phone = new PhoneNumber("39123456789");
        var vet1 = new Veterinary(name1, email, phone, "Cani");
        var vet2 = new Veterinary(name2, email, phone, "Cani");
        Assert.IsFalse(vet1.Equals(vet2));
    }
}
