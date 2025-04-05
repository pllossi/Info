using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VerificaTeoria_Torneo;

namespace VerificaTeoria_TorneoTests
{
    [TestClass]
    public class TestTorneo
    {
        private Giocatore[] CreateSamplePlayers()
        {
            return new Giocatore[]
            {
                new Giocatore("Player1", DateTime.Now, 100, 0),
                new Giocatore("Player2", DateTime.Now, 100, 1),
                new Giocatore("Player3", DateTime.Now, 100, 2)
            };
        }

        [TestMethod]
        public void Torneo_ValidParameters_CreatesInstance()
        {
            Giocatore[] giocatori = CreateSamplePlayers();
            int maxPartite = 5;

            Torneo torneo = new Torneo(giocatori, maxPartite);

            Assert.IsNotNull(torneo);
        }

        [TestMethod]
        public void Torneo_NegativeMaxPartite_ThrowsArgumentOutOfRangeException()
        {
            Giocatore[] giocatori = CreateSamplePlayers();
            int maxPartite = -1;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Torneo(giocatori, maxPartite));
        }

        [TestMethod]
        public void AggiungiPartita_ValidPartita_AddsPartita()
        {
            Giocatore[] giocatori = CreateSamplePlayers();
            Torneo torneo = new Torneo(giocatori, 5);
            Giocatore g1 = giocatori[0];
            Giocatore g2 = giocatori[1];
            Partita partita = new Partita(g1, g2, g1, 0);

            torneo.AggiungiPartita(partita);

            Assert.AreEqual(1, torneo.CalcolaPartiteGiocate(g1));
            Assert.AreEqual(1, torneo.CalcolaPartiteGiocate(g2));
        }

        [TestMethod]
        public void AggiungiPartita_InvalidGiocatore1_ThrowsArgumentOutOfRangeException()
        {
            Giocatore[] giocatori = CreateSamplePlayers();
            Torneo torneo = new Torneo(giocatori, 5);
            Giocatore invalidG1 = new Giocatore("Invalid", DateTime.Now, 100, -1);
            Giocatore g2 = giocatori[1];
            Partita partita = new Partita(invalidG1, g2, g2, 0);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => torneo.AggiungiPartita(partita));
        }

        [TestMethod]
        public void AggiungiPartita_InvalidGiocatore2_ThrowsArgumentOutOfRangeException()
        {
            Giocatore[] giocatori = CreateSamplePlayers();
            Torneo torneo = new Torneo(giocatori, 5);
            Giocatore g1 = giocatori[0];
            Giocatore invalidG2 = new Giocatore("Invalid", DateTime.Now, 100, 10);
            Partita partita = new Partita(g1, invalidG2, g1, 0);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => torneo.AggiungiPartita(partita));
        }

        [TestMethod]
        public void AggiungiPartita_InvalidPartitaNumero_ThrowsArgumentOutOfRangeException()
        {
            Giocatore[] giocatori = CreateSamplePlayers();
            Torneo torneo = new Torneo(giocatori, 3);
            Giocatore g1 = giocatori[0];
            Giocatore g2 = giocatori[1];
            Partita partita = new Partita(g1, g2, g1, 5);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => torneo.AggiungiPartita(partita));
        }

        [TestMethod]
        public void CalcolaPartiteGiocate_GiocatoreWithPartite_ReturnsCorrectCount()
        {
            Giocatore[] giocatori = CreateSamplePlayers();
            Torneo torneo = new Torneo(giocatori, 5);
            Giocatore g1 = giocatori[0];
            Giocatore g2 = giocatori[1];

            Partita partita1 = new Partita(g1, g2, g1, 0);
            Partita partita2 = new Partita(g1, g2, g2, 1);

            torneo.AggiungiPartita(partita1);
            torneo.AggiungiPartita(partita2);

            int partiteGiocate = torneo.CalcolaPartiteGiocate(g1);

            Assert.AreEqual(2, partiteGiocate);
        }

        [TestMethod]
        public void CalcolaPartiteGiocate_GiocatoreSenzaPartite_ReturnsZero()
        {
            Giocatore[] giocatori = CreateSamplePlayers();
            Torneo torneo = new Torneo(giocatori, 5);
            Giocatore g3 = giocatori[2];

            int partiteGiocate = torneo.CalcolaPartiteGiocate(g3);

            Assert.AreEqual(0, partiteGiocate);
        }

        [TestMethod]
        public void CalcolaPartiteGiocate_InvalidGiocatore_ThrowsArgumentOutOfRangeException()
        {
            Giocatore[] giocatori = CreateSamplePlayers();
            Torneo torneo = new Torneo(giocatori, 5);
            Giocatore invalidGiocatore = new Giocatore("Invalid", DateTime.Now, 100, 10);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => torneo.CalcolaPartiteGiocate(invalidGiocatore));
        }

        [TestMethod]
        public void CalcolaVittorie_GiocatoreWithVittorie_ReturnsCorrectCount()
        {
            Giocatore[] giocatori = CreateSamplePlayers();
            Torneo torneo = new Torneo(giocatori, 5);
            Giocatore g1 = giocatori[0];
            Giocatore g2 = giocatori[1];

            Partita partita1 = new Partita(g1, g2, g1, 0);
            Partita partita2 = new Partita(g1, g2, g1, 1);
            Partita partita3 = new Partita(g1, g2, g2, 2);

            torneo.AggiungiPartita(partita1);
            torneo.AggiungiPartita(partita2);
            torneo.AggiungiPartita(partita3);

            int vittorie = torneo.CalcolaVittorie(g1);

            Assert.AreEqual(2, vittorie);
        }

        [TestMethod]
        public void CalcolaVittorie_GiocatoreSenzaVittorie_ReturnsZero()
        {
            Giocatore[] giocatori = CreateSamplePlayers();
            Torneo torneo = new Torneo(giocatori, 5);
            Giocatore g1 = giocatori[0];
            Giocatore g2 = giocatori[1];

            Partita partita = new Partita(g1, g2, g2, 0);
            torneo.AggiungiPartita(partita);

            int vittorie = torneo.CalcolaVittorie(g1);

            Assert.AreEqual(0, vittorie);
        }

        [TestMethod]
        public void CalcolaVittorie_InvalidGiocatore_ThrowsException()
        {
            Giocatore[] giocatori = CreateSamplePlayers();
            Torneo torneo = new Torneo(giocatori, 5);
            Giocatore invalidGiocatore = new Giocatore("Invalid", DateTime.Now, 100, 10);

            Assert.ThrowsException<Exception>(() => torneo.CalcolaVittorie(invalidGiocatore));
        }

        [TestMethod]
        public void CalcolaSconfitte_GiocatoreWithSconfitte_ReturnsCorrectCount()
        {
            Giocatore[] giocatori = CreateSamplePlayers();
            Torneo torneo = new Torneo(giocatori, 5);
            Giocatore g1 = giocatori[0];
            Giocatore g2 = giocatori[1];

            Partita partita1 = new Partita(g1, g2, g2, 0);
            Partita partita2 = new Partita(g1, g2, g2, 1);
            Partita partita3 = new Partita(g1, g2, null, 2);

            torneo.AggiungiPartita(partita1);
            torneo.AggiungiPartita(partita2);
            torneo.AggiungiPartita(partita3);

            int sconfitte = torneo.CalcolaSconfitte(g1);

            Assert.AreEqual(3, sconfitte);
        }

        [TestMethod]
        public void CalcolaSconfitte_GiocatoreSenzaSconfitte_ReturnsZero()
        {
            Giocatore[] giocatori = CreateSamplePlayers();
            Torneo torneo = new Torneo(giocatori, 5);
            Giocatore g1 = giocatori[0];
            Giocatore g2 = giocatori[1];

            Partita partita = new Partita(g1, g2, g1, 0);
            torneo.AggiungiPartita(partita);

            int sconfitte = torneo.CalcolaSconfitte(g1);

            Assert.AreEqual(0, sconfitte);
        }

        [TestMethod]
        public void CalcolaSconfitte_InvalidGiocatore_ThrowsException()
        {
            Giocatore[] giocatori = CreateSamplePlayers();
            Torneo torneo = new Torneo(giocatori, 5);
            Giocatore invalidGiocatore = new Giocatore("Invalid", DateTime.Now, 100, 10);

            Assert.ThrowsException<Exception>(() => torneo.CalcolaSconfitte(invalidGiocatore));
        }

        [TestMethod]
        public void MatriceRisultati_WithPartite_ReturnsCorrectMatrix()
        {
            Giocatore[] giocatori = CreateSamplePlayers();
            Torneo torneo = new Torneo(giocatori, 3);
            Giocatore g1 = giocatori[0];
            Giocatore g2 = giocatori[1];

            Partita partita1 = new Partita(g1, g2, g1, 0);
            Partita partita2 = new Partita(g1, g2, g2, 1);
            Partita partita3 = new Partita(g1, g2, null, 2);

            torneo.AggiungiPartita(partita1);
            torneo.AggiungiPartita(partita2);
            torneo.AggiungiPartita(partita3);

            int[,] matrice = torneo.MatriceRisultati(3);

            Assert.AreEqual(1, matrice[0, 0]);
            Assert.AreEqual(-1, matrice[0, 1]);
            Assert.AreEqual(0, matrice[0, 2]);

            Assert.AreEqual(-1, matrice[1, 0]);
            Assert.AreEqual(1, matrice[1, 1]);
            Assert.AreEqual(0, matrice[1, 2]);

            Assert.AreEqual(0, matrice[2, 0]);
            Assert.AreEqual(0, matrice[2, 1]);
            Assert.AreEqual(0, matrice[2, 2]);
        }

        [TestMethod]
        public void MatriceRisultati_EmptyTorneo_ReturnsEmptyMatrix()
        {
            Giocatore[] giocatori = CreateSamplePlayers();
            Torneo torneo = new Torneo(giocatori, 3);

            int[,] matrice = torneo.MatriceRisultati(3);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(0, matrice[i, j]);
                }
            }
        }
    }
}