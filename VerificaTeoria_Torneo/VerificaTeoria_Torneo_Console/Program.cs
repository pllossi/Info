using System;
using VerificaTeoria_Torneo;

namespace VerificaTeoria_Torneo_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Giocatore giocatore1 = new Giocatore("Giocatore 1", DateTime.Now, 100, 1);
            Giocatore giocatore2 = new Giocatore("Giocatore 2", DateTime.Now, 200, 2);
            Giocatore giocatore3 = new Giocatore("Giocatore 3", DateTime.Now, 150, 3);
            Giocatore[] giocatori = { giocatore1, giocatore2, giocatore3 };
            Torneo torneo = new Torneo(giocatori, 10);

            Partita partita1 = new Partita(giocatore1, giocatore2, giocatore1);
            Partita partita2 = new Partita(giocatore1, giocatore3, giocatore3);
            Partita partita3 = new Partita(giocatore2, giocatore3, null);

            torneo.AggiungiPartita(partita1);
            torneo.AggiungiPartita(partita2);
            torneo.AggiungiPartita(partita3);

            Console.WriteLine("Partite giocate da Giocatore 1: " + torneo.CalcolaPartiteGiocate(giocatore1));
            Console.WriteLine("Partite giocate da Giocatore 2: " + torneo.CalcolaPartiteGiocate(giocatore2));
            Console.WriteLine("Partite giocate da Giocatore 3: " + torneo.CalcolaPartiteGiocate(giocatore3));

            Console.WriteLine("Vittorie di Giocatore 1: " + torneo.CalcolaVittorie(giocatore1));
            Console.WriteLine("Vittorie di Giocatore 2: " + torneo.CalcolaVittorie(giocatore2));
            Console.WriteLine("Vittorie di Giocatore 3: " + torneo.CalcolaVittorie(giocatore3));

            Console.WriteLine("Sconfitte di Giocatore 1: " + torneo.CalcolaSconfitte(giocatore1));
            Console.WriteLine("Sconfitte di Giocatore 2: " + torneo.CalcolaSconfitte(giocatore2));
            Console.WriteLine("Sconfitte di Giocatore 3: " + torneo.CalcolaSconfitte(giocatore3));

            int[,] risultati = torneo.MatriceRisultati();
            Console.WriteLine("Matrice dei risultati:");
            for (int i = 0; i < risultati.GetLength(0); i++)
            {
                for (int j = 0; j < risultati.GetLength(1); j++)
                {
                    Console.Write(risultati[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
