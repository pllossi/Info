using NoleggiLib;

namespace NoleggioTest;

[TestClass]
public class MotociclettaTest
{
    [TestMethod]
    public void Ctrl_ValidParameters_CreatesInstance()
    {
        var moto = new Motocicletta(35.0, "MOTO123", TipoCasco.INTEGRALE);
        Assert.AreEqual(35.0, moto.PrezzoPerGiorno);
        Assert.AreEqual("MOTO123", moto.Targa);
        Assert.AreEqual(TipoCasco.INTEGRALE, moto.Casco);
    }

    [TestMethod]
    public void Casco_SetAndGet_WorksCorrectly()
    {
        var moto = new Motocicletta(40.0, "MOTO456", TipoCasco.JET);
        moto.Casco = TipoCasco.CROSS;
        Assert.AreEqual(TipoCasco.CROSS, moto.Casco);
    }

    [TestMethod]
    public void Descrizione_ReturnsExpectedString()
    {
        var moto = new Motocicletta(50.0, "MOTO789", TipoCasco.SEMI_INTEGRALE);
        var descrizione = moto.Descrizione();
        Assert.IsTrue(descrizione.Contains("Motocicletta"));
        Assert.IsTrue(descrizione.Contains("Targa: MOTO789"));
        Assert.IsTrue(descrizione.Contains("Prezzo per giorno: 50"));
        Assert.IsTrue(descrizione.Contains("casco di tipo SEMI_INTEGRALE"));
    }

    [TestMethod]
    public void Costo_2Giorni_CalculatesCorrectly()
    {
        var moto = new Motocicletta(30.0, "MOTO321", TipoCasco.JET);
        var Noleggio = new Noleggio(moto, 2);
        var costo = Noleggio.CalcolaCostoNoleggio();
        Assert.AreEqual(60.0, costo);
    }
}
