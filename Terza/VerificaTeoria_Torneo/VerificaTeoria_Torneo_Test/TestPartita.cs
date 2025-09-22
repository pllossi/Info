using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VerificaTeoria_Torneo;

namespace VerificaTeoria_TorneoTests
{
    [TestClass]
    public class TestPartita
    {
        [TestMethod]
        public void Partita_ValidParameters_CreatesInstance()
        {
            Giocatore g1 = new Giocatore("Player1", DateTime.Now, 100, 0);
            Giocatore g2 = new Giocatore("Player2", DateTime.Now, 100, 1);

            Partita partita = new Partita(g1, g2, g1, 1);

            Assert.IsNotNull(partita);
            Assert.AreEqual(g1, partita.Giocatore1);
            Assert.AreEqual(g2, partita.Giocatore2);
            Assert.AreEqual(g1, partita.Vincitore);
            Assert.AreEqual(1, partita.Numero);
        }

        [TestMethod]
        public void Partita_NullGiocatore1_ThrowsArgumentNullException()
        {
            Giocatore g2 = new Giocatore("Player2", DateTime.Now, 100, 1);

            Assert.ThrowsException<ArgumentNullException>(() => new Partita(null, g2, g2, 1));
        }

        [TestMethod]
        public void Partita_NullGiocatore2_ThrowsArgumentNullException()
        {
            Giocatore g1 = new Giocatore("Player1", DateTime.Now, 100, 0);

            Assert.ThrowsException<ArgumentNullException>(() => new Partita(g1, null, g1, 1));
        }

        [TestMethod]
        public void Partita_NegativeNumero_ThrowsArgumentOutOfRangeException()
        {
            Giocatore g1 = new Giocatore("Player1", DateTime.Now, 100, 0);
            Giocatore g2 = new Giocatore("Player2", DateTime.Now, 100, 1);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Partita(g1, g2, g1, -1));
        }

        [TestMethod]
        public void Partita_SameGiocatori_ThrowsArgumentException()
        {
            Giocatore g1 = new Giocatore("Player1", DateTime.Now, 100, 0);
            Giocatore g1Copy = new Giocatore("Player1Copy", DateTime.Now, 100, 0);

            Assert.ThrowsException<ArgumentException>(() => new Partita(g1, g1Copy, g1, 1));
        }

        [TestMethod]
        public void Partita_InvalidVincitore_ThrowsArgumentException()
        {
            Giocatore g1 = new Giocatore("Player1", DateTime.Now, 100, 0);
            Giocatore g2 = new Giocatore("Player2", DateTime.Now, 100, 1);
            Giocatore g3 = new Giocatore("Player3", DateTime.Now, 100, 2);

            Assert.ThrowsException<ArgumentException>(() => new Partita(g1, g2, g3, 1));
        }

        [TestMethod]
        public void Partita_NullVincitore_CreatesInstance()
        {
            Giocatore g1 = new Giocatore("Player1", DateTime.Now, 100, 0);
            Giocatore g2 = new Giocatore("Player2", DateTime.Now, 100, 1);

            Partita partita = new Partita(g1, g2, null, 1);

            Assert.IsNotNull(partita);
            Assert.IsNull(partita.Vincitore);
        }
    }
}