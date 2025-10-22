using Domain.Entities;

namespace DomainTests.Entities;

[TestClass]
public class GattoTest
{
    [TestMethod]
    public void Costruttore_ValoriValidi_OttengoIstanza()
    {
        var dataArrivo = DateTime.Now;
        var dataNascita = new DateTime(2020, 1, 1);
        var gatto = new Gatto("Micio", "Europeo", true, "Descrizione", null, dataNascita);
        gatto.DataArrivoGattile = dataArrivo;
        Assert.AreEqual("Micio", gatto.Nome);
        Assert.AreEqual("Europeo", gatto.Razza);
        Assert.IsTrue(gatto.Maschio);
        Assert.AreEqual("Descrizione", gatto.Descrizione);
        Assert.IsNotNull(gatto.CodiceId);
        Assert.AreEqual(dataNascita, gatto.DataNascita);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Costruttore_NomeVuoto_LanciaArgumentException()
    {
        var _ = new Gatto("", "Europeo");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Costruttore_RazzaVuota_LanciaArgumentException()
    {
        var _ = new Gatto("Micio", "");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Descrizione_ImpostaVuota_LanciaArgumentException()
    {
        var gatto = new Gatto("Micio", "Europeo");
        gatto.Descrizione = "";
    }

    [TestMethod]
    public void CodiceId_Creazione_OttengoValoreUnicoNonVuoto()
    {
        var gatto1 = new Gatto("Micio", "Europeo");
        var gatto2 = new Gatto("Fuffy", "Siamese");
        Assert.IsFalse(string.IsNullOrWhiteSpace(gatto1.CodiceId));
        Assert.IsFalse(string.IsNullOrWhiteSpace(gatto2.CodiceId));
        Assert.AreNotEqual(gatto1.CodiceId, gatto2.CodiceId);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void DataArrivoGattile_MaggioreDiDataUscita_LanciaArgumentException()
    {
        var dataUscita = DateTime.Now.AddDays(-1);
        var gatto = new Gatto("Micio", "Europeo", true, null, dataUscita);
        gatto.DataArrivoGattile = DateTime.Now;
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void DataUscita_MaggioreDiDataArrivoGattile_LanciaArgumentException()
    {
        var gatto = new Gatto("Micio", "Europeo");
        gatto.DataUscita = DateTime.Now.AddDays(1);
    }

    [TestMethod]
    public void DataNascita_ImpostaValore_OttengoValore()
    {
        var gatto = new Gatto("Micio", "Europeo");
        var dataNascita = new DateTime(2019, 5, 20);
        gatto.DataNascita = dataNascita;
        Assert.AreEqual(dataNascita, gatto.DataNascita);
    }
}
