using Domain.Entities;

namespace DomainTests.Entities;

[TestClass]
public class CatTest
{
    [TestMethod]
    public void Constructor_ValidValues_ReturnsInstance()
    {
        var arrivalDate = DateTime.Now;
        var birthDate = new DateTime(2020, 1, 1);
        var cat = new Cat("Micio", "European", true, "Description", null, birthDate);
        cat.ShelterArrivalDate = arrivalDate;
        Assert.AreEqual("Micio", cat.Name);
        Assert.AreEqual("European", cat.Breed);
        Assert.IsTrue(cat.Male);
        Assert.AreEqual("Description", cat.Description);
        Assert.IsNotNull(cat.CodeId);
        Assert.AreEqual(birthDate, cat.BirthDate);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Constructor_EmptyName_ThrowsArgumentException()
    {
        var _ = new Cat("", "European");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Constructor_EmptyBreed_ThrowsArgumentException()
    {
        var _ = new Cat("Micio", "");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Description_SetEmpty_ThrowsArgumentException()
    {
        var cat = new Cat("Micio", "European");
        cat.Description = "";
    }

    [TestMethod]
    public void CodeId_Creation_ReturnsUniqueNonEmptyValue()
    {
        var cat1 = new Cat("Micio", "European");
        var cat2 = new Cat("Fuffy", "Siamese");
        Assert.IsFalse(string.IsNullOrWhiteSpace(cat1.CodeId));
        Assert.IsFalse(string.IsNullOrWhiteSpace(cat2.CodeId));
        Assert.AreNotEqual(cat1.CodeId, cat2.CodeId);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void ShelterArrivalDate_GreaterThanExitDate_ThrowsArgumentException()
    {
        var exitDate = DateTime.Now.AddDays(-1);
        var cat = new Cat("Micio", "European", true, null, exitDate);
        cat.ShelterArrivalDate = DateTime.Now;
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void ExitDate_GreaterThanShelterArrivalDate_ThrowsArgumentException()
    {
        var cat = new Cat("Micio", "European");
        cat.ExitDate = DateTime.Now.AddDays(1);
    }

    [TestMethod]
    public void BirthDate_SetValue_ReturnsValue()
    {
        var cat = new Cat("Micio", "European");
        var birthDate = new DateTime(2019, 5, 20);
        cat.BirthDate = birthDate;
        Assert.AreEqual(birthDate, cat.BirthDate);
    }
}
