using Domain.Model.Entities;
using Domain.Model.ValueObjects;

namespace TestDomain;

[TestClass]
public class TestVeterinaryVisit
{
    private class TestAnimal : Animal
    {
        public TestAnimal(string name) : base(name) { }
    }

    [TestMethod]
    public void VeterinaryVisit_Constructor_SetsProperties()
    {
        var animal = new TestAnimal("Fido");
        var vet = new Veterinary(
            new FullName("Mario", "Rossi"),
            new Email("mario.rossi@vet.com"),
            new PhoneNumber("39123456789"),
            "Cani"
        );
        var date = new DateTime(2024, 6, 1, 10, 30, 0);
        var result = VisitResults.POSITIVE;
        var notes = "Controllo annuale";
        var visit = new VeterinaryVisit(animal, vet, date, result, notes);
        Assert.AreEqual(animal, visit.Animal);
        Assert.AreEqual(vet, visit.Veterinary);
        Assert.AreEqual(date, visit.Date);
        Assert.AreEqual(result, visit.Results);
        Assert.AreEqual(notes, visit.Notes);
    }

    [TestMethod]
    public void VeterinaryVisit_Constructor_WithoutNotes_AllowsNull()
    {
        var animal = new TestAnimal("Fido");
        var vet = new Veterinary(
            new FullName("Mario", "Rossi"),
            new Email("mario.rossi@vet.com"),
            new PhoneNumber("39123456789"),
            "Cani"
        );
        var date = DateTime.Now;
        var result = VisitResults.NEGATIVE;
        var visit = new VeterinaryVisit(animal, vet, date, result);
        Assert.IsNull(visit.Notes);
    }

    [TestMethod]
    public void VeterinaryVisit_ToString_ReturnsExpectedFormat()
    {
        var animal = new TestAnimal("Fido");
        var vet = new Veterinary(
            new FullName("Mario", "Rossi"),
            new Email("mario.rossi@vet.com"),
            new PhoneNumber("39123456789"),
            "Cani"
        );
        var date = new DateTime(2024, 6, 1);
        var visit = new VeterinaryVisit(animal, vet, date, VisitResults.WAITING, "Note");
        var expected = $"{date.ToShortDateString()} - {animal.Name} visited by {vet.Name}";
        Assert.AreEqual(expected, visit.ToString());
    }

    [TestMethod]
    public void VeterinaryVisit_Results_AllEnumValues()
    {
        var animal = new TestAnimal("Fido");
        var vet = new Veterinary(
            new FullName("Mario", "Rossi"),
            new Email("mario.rossi@vet.com"),
            new PhoneNumber("39123456789"),
            "Cani"
        );
        var date = DateTime.Now;
        foreach (VisitResults result in Enum.GetValues(typeof(VisitResults)))
        {
            var visit = new VeterinaryVisit(animal, vet, date, result);
            Assert.AreEqual(result, visit.Results);
        }
    }
}
