namespace TreasureHuntGame // Definisce il namespace del progetto.
{
    public class Player // Classe che rappresenta il giocatore.
    {
        public int Moves { get; private set; }  // Proprietà che tiene traccia del numero di mosse effettuate.

        public Player() // Costruttore della classe Player.
        {
            Moves = 0; // Inizializza il numero di mosse a 0.
        }

        // Metodo per incrementare il conteggio delle mosse.
        public void IncrementMoves()
        {
            Moves++;  // Aumenta il numero di mosse di 1.
        }
    }
}
