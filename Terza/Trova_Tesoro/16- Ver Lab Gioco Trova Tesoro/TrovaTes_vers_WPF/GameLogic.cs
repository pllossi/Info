using System; // Importa il namespace System per utilizzare funzionalità come Random.

namespace TreasureHuntGame // Definisce il namespace del progetto.
{
    public class GameLogic // Definizione della classe principale che gestisce la logica del gioco.
    {
        private int treasureX;  // Variabile per memorizzare la coordinata X del tesoro.
        private int treasureY;  // Variabile per memorizzare la coordinata Y del tesoro.
        private Random random;  // Instanza per generare numeri casuali.

        public GameLogic() // Costruttore della classe GameLogic.
        {
            random = new Random(); // Inizializza l'oggetto Random per generare numeri casuali.
        }

        // Metodo per posizionare il tesoro casualmente nella griglia.
        public (int, int) PlaceTreasure(int rows, int cols) // Ritorna una tupla con le coordinate del tesoro.
        {
            treasureX = random.Next(rows);
            treasureY = random.Next(cols);
            return (treasureX, treasureY);  // Ritorna la posizione del tesoro.
        }

        // Metodo per verificare se il tesoro è stato trovato.
        public bool IsTreasureFound(int x, int y)  // Controlla se le coordinate del giocatore corrispondono al tesoro.
        {
            return x == treasureX && y == treasureY;  // Ritorna true se le coordinate coincidono.
        }
    }
}