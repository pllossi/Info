using Domain.Model.Entities;
using Domain.Model.ValueObjects;

namespace TestDomain;

[TestClass]
public class TestDog
{
    [TestMethod]
    public void Dog_Constructor_WithName_SetsName()
    {
        var name = "Fido";
        var dog = new Dog(name);
        Assert.AreEqual(name, dog.Name);
        Assert.IsNull(dog.Breed);
        Assert.IsNull(dog.FavouriteChewing);
        Assert.IsNotNull(dog.VisitList);
        Assert.AreEqual(0, dog.VisitList.Count);
    }

    [TestMethod]
    public void Dog_Constructor_WithVisits_SetsVisits()
    {
        var name = "Fido";
        var visits = new List<VeterinaryVisit>();
        var dog = new Dog(name, visits);
        Assert.AreEqual(name, dog.Name);
        Assert.AreSame(visits, dog.VisitList);
    }

    [TestMethod]
    public void Dog_Constructor_WithAllParameters_SetsProperties()
    {
        var name = "Rex";
        var birthdate = new Birthdate(new DateOnly(2019, 3, 15));
        var breed = "Labrador";
        var favouriteChewing = "Osso";
        var dog = new Dog(name, birthdate, breed, favouriteChewing);
        Assert.AreEqual(name, dog.Name);
        Assert.AreEqual(birthdate, dog.Birthday);
        Assert.AreEqual(breed, dog.Breed);
        Assert.AreEqual(favouriteChewing, dog.FavouriteChewing);
        Assert.IsNotNull(dog.VisitList);
        Assert.AreEqual(0, dog.VisitList.Count);
    }

    [TestMethod]
    public void Dog_Constructor_WithAllParametersAndVisits_SetsAllProperties()
    {
        var name = "Rex";
        var birthdate = new Birthdate(new DateOnly(2019, 3, 15));
        var breed = "Labrador";
        var favouriteChewing = "Osso";
        var visits = new List<VeterinaryVisit>();
        var dog = new Dog(name, birthdate, breed, favouriteChewing, visits);
        Assert.AreEqual(name, dog.Name);
        Assert.AreEqual(birthdate, dog.Birthday);
        Assert.AreEqual(breed, dog.Breed);
        Assert.AreEqual(favouriteChewing, dog.FavouriteChewing);
        Assert.AreSame(visits, dog.VisitList);
    }

    [TestMethod]
    public void Dog_FavouriteChewing_SetNull_AllowsNull()
    {
        var dog = new Dog("Fido");
        dog.FavouriteChewing = null;
        Assert.IsNull(dog.FavouriteChewing);
    }

    [TestMethod]
    public void Dog_FavouriteChewing_SetEmpty_Throws()
    {
        var dog = new Dog("Fido");
        Assert.ThrowsException<ArgumentException>(() => dog.FavouriteChewing = "");
    }

    [TestMethod]
    public void Dog_AddVisit_AddsVisitToList()
    {
        var dog = new Dog("Fido");
        var vet = new Veterinary(
            new FullName("Mario", "Rossi"),
            new Email("mario.rossi@vet.com"),
            new PhoneNumber("39123456789"),
            "Cani"
        );
        var visit = new VeterinaryVisit(dog, vet, DateTime.Now, VisitResults.POSITIVE);
        dog.AddVisit(visit);
        Assert.AreEqual(1, dog.VisitList.Count);
        Assert.AreSame(visit, dog.VisitList[0]);
    }
}
