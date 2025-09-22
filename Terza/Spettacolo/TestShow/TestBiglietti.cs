using Microsoft.VisualStudio.TestTools.UnitTesting;
using Show;

namespace ShowTests
{
    [TestClass]
    public class BigliettoTests
    {
        [TestMethod]
        public void TestBigliettoCreation_PrezzoAndPosto_SetCorrectValuesAndNotSold()
        {
            double prezzo = 50.0;
            int posto = 10;
            Biglietto biglietto = new Biglietto(prezzo, posto);

            Assert.AreEqual(prezzo, biglietto.Prezzo);
            Assert.AreEqual(posto, biglietto.Posto);
            Assert.IsFalse(biglietto.Venduto);
        }

        [TestMethod]
        public void TestBigliettoCreation_InvalidPrezzo_ThrowsException()
        {
            double prezzo = -10.0;
            int posto = 10;
            Assert.ThrowsException<System.Exception>(() => new Biglietto(prezzo, posto));
        }

        [TestMethod]
        public void TestBigliettoCreation_InvalidPosto_ThrowsException()
        {
            double prezzo = 50.0;
            int posto = -1;
            Assert.ThrowsException<System.Exception>(() => new Biglietto(prezzo, posto));
        }

        [TestMethod]
        public void TestVendita_BigliettoNotSold_SetsVendutoToTrue()
        {
            double prezzo = 50.0;
            int posto = 10;
            Biglietto biglietto = new Biglietto(prezzo, posto);

            biglietto.Vendita();
            Assert.IsTrue(biglietto.Venduto);
        }

        [TestMethod]
        public void TestVendita_BigliettoAlreadySold_ThrowsException()
        {
            double prezzo = 50.0;
            int posto = 10;
            Biglietto biglietto = new Biglietto(prezzo, posto);

            biglietto.Vendita();
            Assert.ThrowsException<System.Exception>(() => biglietto.Vendita());
        }

        [TestMethod]
        public void TestReso_BigliettoSold_ResetsVendutoToFalse()
        {
            double prezzo = 50.0;
            int posto = 10;
            Biglietto biglietto = new Biglietto(prezzo, posto);

            biglietto.Vendita();
            biglietto.Reso();
            Assert.IsFalse(biglietto.Venduto);
        }

        [TestMethod]
        public void TestReso_BigliettoNotSold_ThrowsException()
        {
            double prezzo = 50.0;
            int posto = 10;
            Biglietto biglietto = new Biglietto(prezzo, posto);

            Assert.ThrowsException<System.Exception>(() => biglietto.Reso());
        }
    }
}
