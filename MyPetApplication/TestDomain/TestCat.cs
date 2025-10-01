using Domain.Model.Entities;
using Domain.Model.ValueObjects;

namespace TestDomain;

[TestClass]
public class TestCat
{
    [TestMethod]
    public void Cat_Constructor_WithName_SetsName()
    {
        var name = "Micio";
        var cat = new Cat(name);
        Assert.AreEqual(name, cat.Name);
        Assert.IsNull(cat.Breed);
        Assert.IsNotNull(cat.VisitList);
        Assert.AreEqual(0, cat.VisitList.Count);
    }

    [TestMethod]
    public void Cat_Constructor_WithVisits_SetsVisits()
    {
        var name = "Micio";
        var visits = new List<VeterinaryVisit>();
        var cat = new Cat(name, visits);
        Assert.AreEqual(name, cat.Name);
        Assert.AreSame(visits, cat.VisitList);
    }

    [TestMethod]
    public void Cat_Constructor_WithAllParameters_SetsProperties()
    {
        var name = "Luna";
        var birthdate = new Birthdate(new DateOnly(2020, 5, 10));
        var breed = "Siamese";
        var cat = new Cat(name, birthdate, breed);
        Assert.AreEqual(name, cat.Name);
        Assert.AreEqual(birthdate, cat.Birthday);
        Assert.AreEqual(breed, cat.Breed);
        Assert.IsNotNull(cat.VisitList);
        Assert.AreEqual(0, cat.VisitList.Count);
    }

    [TestMethod]
    public void Cat_Constructor_WithAllParametersAndVisits_SetsAllProperties()
    {
        var name = "Luna";
        var birthdate = new Birthdate(new DateOnly(2020, 5, 10));
        var breed = "Siamese";
        var visits = new List<VeterinaryVisit>();
        var cat = new Cat(name, birthdate, breed, visits);
        Assert.AreEqual(name, cat.Name);
        Assert.AreEqual(birthdate, cat.Birthday);
        Assert.AreEqual(breed, cat.Breed);
        Assert.AreSame(visits, cat.VisitList);
    }

    [TestMethod]
    public void Cat_AddVisit_AddsVisitToList()
    {
        var name = "Micio";
        var cat = new Cat(name);
        var vet = new Veterinary(
            new FullName("Mario", "Rossi"),
            new Email("mario.rossi@vet.com"),
            new PhoneNumber("39123456789"),
            "Gatti"
        );
        var visit = new VeterinaryVisit(cat, vet, DateTime.Now, VisitResults.POSITIVE);
        cat.AddVisit(visit);
        Assert.AreEqual(1, cat.VisitList.Count);
        Assert.AreSame(visit, cat.VisitList[0]);
    }
}
