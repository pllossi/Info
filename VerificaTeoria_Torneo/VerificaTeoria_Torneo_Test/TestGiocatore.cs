using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VerificaTeoria_Torneo;

namespace VerificaTeoria_TorneoTests
{
    [TestClass]
    public class TestGiocatore
    {
        [TestMethod]
        public void Giocatore_ValidParameters_CreatesInstance()
        {
            string nome = "TestPlayer";
            DateTime data = new DateTime(2023, 1, 1);
            int punteggioMassimo = 100;
            int numero = 1;

            Giocatore giocatore = new Giocatore(nome, data, punteggioMassimo, numero);

            Assert.IsNotNull(giocatore);
            Assert.AreEqual(nome, giocatore.Nome);
            Assert.AreEqual(data, giocatore.DataIscrizione);
            Assert.AreEqual(punteggioMassimo, giocatore.PunteggioMassimo);
            Assert.AreEqual(numero, giocatore.Numero);
        }

        [TestMethod]
        public void Giocatore_ModifyProperties_UpdatesValues()
        {
            Giocatore giocatore = new Giocatore("OldName", DateTime.Now, 50, 5);
            string newName = "NewName";
            DateTime newDate = new DateTime(2024, 1, 1);
            int newPunteggio = 150;

            giocatore.Nome = newName;
            giocatore.DataIscrizione = newDate;
            giocatore.PunteggioMassimo = newPunteggio;

            Assert.AreEqual(newName, giocatore.Nome);
            Assert.AreEqual(newDate, giocatore.DataIscrizione);
            Assert.AreEqual(newPunteggio, giocatore.PunteggioMassimo);
            Assert.AreEqual(5, giocatore.Numero);
        }
    }
}