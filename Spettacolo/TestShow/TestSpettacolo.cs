using Microsoft.VisualStudio.TestTools.UnitTesting;
using Show;
using System;

namespace ShowTests
{
    [TestClass]
    public class SpettacoloTests
    {
        [TestMethod]
        public void TestSpettacoloCreation_CorrectInitialization_ExpectedValues()
        {
            string titolo = "Concerto";
            DateTime data = DateTime.Now.AddDays(10);
            int nBiglietti = 100;
            double costo = 50.0;
            Spettacolo spettacolo = new Spettacolo(titolo, data, nBiglietti, costo);

            Assert.AreEqual(titolo, spettacolo.Titolo);
            Assert.AreEqual(data, spettacolo.Data);
            Assert.AreEqual(nBiglietti, spettacolo.Biglietti.Length);
            foreach (var biglietto in spettacolo.Biglietti)
            {
                Assert.AreEqual(costo, biglietto.Prezzo);
                Assert.IsFalse(biglietto.Venduto);
            }
        }

        [TestMethod]
        public void TestSpettacoloInvalidTitolo_EmptyTitolo_ExceptionThrown()
        {
            string titolo = "";
            DateTime data = DateTime.Now.AddDays(10);
            int nBiglietti = 100;
            double costo = 50.0;

            var ex = Assert.ThrowsException<Exception>(() => new Spettacolo(titolo, data, nBiglietti, costo));
            Assert.AreEqual("Titolo non valido", ex.Message);
        }

        [TestMethod]
        public void TestSpettacoloInvalidData_NegativeData_ExceptionThrown()
        {
            string titolo = "Concerto";
            DateTime data = DateTime.Now.AddDays(-10);
            int nBiglietti = 100;
            double costo = 50.0;

            var ex = Assert.ThrowsException<Exception>(() => new Spettacolo(titolo, data, nBiglietti, costo));
            Assert.AreEqual("Data non valida", ex.Message);
        }

        [TestMethod]
        public void TestVenditaSingoloPosto_SellSingleTicket_TicketMarkedAsSold()
        {
            string titolo = "Concerto";
            DateTime data = DateTime.Now.AddDays(10);
            int nBiglietti = 100;
            double costo = 50.0;
            Spettacolo spettacolo = new Spettacolo(titolo, data, nBiglietti, costo);

            spettacolo.Vendita(1);
            Assert.IsTrue(spettacolo.Biglietti[0].Venduto);
        }

        [TestMethod]
        public void TestVenditaMultipliPosti_valoriPositivi_TicketsMarkedAsSold()
        {
            string titolo = "Concerto";
            DateTime data = DateTime.Now.AddDays(10);
            int nBiglietti = 100;
            double costo = 50.0;
            Spettacolo spettacolo = new Spettacolo(titolo, data, nBiglietti, costo);

            int[] posti = { 1, 2, 3 };
            spettacolo.Vendita(posti);
            foreach (var posto in posti)
            {
                Assert.IsTrue(spettacolo.Biglietti[posto - 1].Venduto);
            }
        }

        [TestMethod]
        public void TestResoSingoloPosto_ReturnSingleTicket_TicketMarkedAsNotSold()
        {
            string titolo = "Concerto";
            DateTime data = DateTime.Now.AddDays(10);
            int nBiglietti = 100;
            double costo = 50.0;
            Spettacolo spettacolo = new Spettacolo(titolo, data, nBiglietti, costo);

            spettacolo.Vendita(1);
            spettacolo.Reso(1);
            Assert.IsFalse(spettacolo.Biglietti[0].Venduto);
        }
    }
}

