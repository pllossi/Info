using System;

namespace TreasureHuntGame
{
    public class GameLogic
    {
        private int[,] grid; // Matrice che rappresenta la griglia di gioco.
        private int treasureX; // Coordinata X del tesoro.
        private int treasureY; // Coordinata Y del tesoro.

        // Costruttore della classe: inizializza la griglia e posiziona il tesoro.
        public GameLogic(int rows, int cols)
        {
            grid = new int[rows, cols];
            PlaceTreasure();
        }

        // Metodo per posizionare casualmente il tesoro nella griglia.
        private void PlaceTreasure()
        {
            Random random = new Random();
            treasureX = random.Next(grid.GetLength(0)); // Genera una posizione casuale per X.
            treasureY = random.Next(grid.GetLength(1)); // Genera una posizione casuale per Y.
            grid[treasureX, treasureY] = 1; // 1 indica che il tesoro è presente.
        }

        // Metodo per verificare se il giocatore ha trovato il tesoro.
        public bool CheckTreasure(int x, int y)
        {
            return x == treasureX && y == treasureY;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto nel gioco della caccia al tesoro!");

            // Creazione della griglia di gioco (esempio: 5x5).
            int rows = 5, cols = 5;
            GameLogic game = new GameLogic(rows, cols);

            bool hasFoundTreasure = false;

            while (!hasFoundTreasure)
            {
                int x = GetValidInput("Inserisci la coordinata X: ", 0, rows);
                int y = GetValidInput("Inserisci la coordinata Y: ", 0, cols);

                if (game.CheckTreasure(x, y))
                {
                    Console.WriteLine("Hai trovato il tesoro! Congratulazioni!");
                    hasFoundTreasure = true;
                }
                else
                {
                    Console.WriteLine("Il tesoro non si trova qui. Riprova!");
                }
            }

            Console.WriteLine("Grazie per aver giocato!");
        }

        static int GetValidInput(string prompt, int min, int max)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out result) && result >= min && result < max)
                {
                    return result;
                }
                Console.WriteLine($"Inserisci un numero tra {min} e {max - 1}.");
            }
        }
    }
}
