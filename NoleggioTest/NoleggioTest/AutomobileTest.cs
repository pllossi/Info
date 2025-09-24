using NoleggiLib;

namespace NoleggioTest;

[TestClass]
public class AutomobileTest
{
    [TestMethod]
    public void Constructor_ValidParameters_CreatesInstance()
    {
        var auto = new Automobile(45.5, "AB123CD", 5);
        Assert.AreEqual(45.5, auto.PrezzoPerGiorno);
        Assert.AreEqual("AB123CD", auto.Targa);
        Assert.AreEqual(5, auto.Posti);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Constructor_InvalidPosti_ThrowsException()
    {
        var auto = new Automobile(30, "XY987ZT", 0);
    }

    [TestMethod]
    public void SetPosti_ValidValue_UpdatesProperty()
    {
        var auto = new Automobile(50, "CD456EF", 4);
        auto.Posti = 2;
        Assert.AreEqual(2, auto.Posti);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void SetPosti_InvalidValue_ThrowsException()
    {
        var auto = new Automobile(50, "CD456EF", 4);
        auto.Posti = 0;
    }

    [TestMethod]
    public void Descrizione_ReturnsExpectedString()
    {
        var auto = new Automobile(60, "EF789GH", 4);
        var descrizione = auto.Descrizione();
        Assert.IsTrue(descrizione.Contains("Automobile"));
        Assert.IsTrue(descrizione.Contains("Targa: EF789GH"));
        Assert.IsTrue(descrizione.Contains("Prezzo per giorno: 60"));
        Assert.IsTrue(descrizione.Contains("4 posti"));
    }

    [TestMethod]
    public void CalcolaCostoNoleggio_WithOutSale_CalculatesCorrectly()
    {
        var auto = new Automobile(70, "GH123IJ", 5);
        var Noleggio = new Noleggio(auto, 3);
        var costo = Noleggio.CalcolaCostoNoleggio();
        Assert.AreEqual(210.0, costo);
    }
}
