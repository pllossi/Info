using NoleggiLib;

namespace NoleggioTest;

[TestClass]
public class BiciclettaTest
{
    [TestMethod]
    public void Constructor_ValidParameters_CreatesInstance()
    {
        var bici = new Bicicletta(12.5, "BICI123");
        Assert.AreEqual(12.5, bici.PrezzoPerGiorno);
        Assert.AreEqual("BICI123", bici.Targa);
    }

    [TestMethod]
    public void Descrizione_ReturnsExpectedString()
    {
        var bici = new Bicicletta(15, "BICI456");
        var descrizione = bici.Descrizione();
        Assert.IsTrue(descrizione.Contains("Bicicletta"));
        Assert.IsTrue(descrizione.Contains("Targa: BICI456"));
        Assert.IsTrue(descrizione.Contains("Prezzo per giorno: 15"));
    }

    [TestMethod]
    public void CalcolaCostoNoleggio_WithOutSale_CalculatesCorrectly()
    {
        var bici = new Bicicletta(20, "BICI789");
        var Noleggio = new Noleggio(bici, 4);
        var costo = Noleggio.CalcolaCostoNoleggio();
        Assert.AreEqual(80, costo);
    }

    [TestMethod]
    public void CalcolaCostoNoleggio_WithSale_CalculatesCorrectly()
    {
        var bici = new Bicicletta(10, "BICI101");
        var Noleggio = new Noleggio(bici, 10);
        var costo = Noleggio.CalcolaCostoNoleggio();
        Assert.AreEqual(90.0, costo);
    }
}
