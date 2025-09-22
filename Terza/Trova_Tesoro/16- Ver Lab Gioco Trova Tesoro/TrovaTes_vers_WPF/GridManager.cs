namespace TreasureHuntGame // Definisce il namespace del progetto.
{
    public class GridManager // Classe responsabile della gestione della griglia.
    {
        private int[,] grid;  // Dichiarazione della matrice che rappresenta la griglia.
        private GameLogic gameLogic; //Dichiarazione di gameLogic(Inserzione di Boschi)(Serve a piazzare il tesoro)

        public GridManager(int rows, int cols)  // Costruttore della classe GridManager.
        {
            grid = new int[rows, cols];  // Inizializza la matrice con le dimensioni specificate.
            gameLogic = new GameLogic(); //Inizializza GameLogic(Inserzione di Boschi)
            gameLogic.PlaceTreasure(rows, cols);//inserisco il tesoro (Inserzione di Boschi)
        }

        // Metodo per resettare la griglia, impostando tutti i valori a 0.
        public void ResetGrid()
        {
            for (int i = 0; i < grid.GetLength(0); i++) // Ciclo per ogni riga della griglia.
                for (int j = 0; j < grid.GetLength(1); j++) // Ciclo per ogni colonna della griglia.
                    grid[i, j] = 0; // Imposta il valore della cella corrente a 0.
        }


        // Metodo per aggiornare una cella specifica nella griglia.
        public void UpdateCell(int x, int y, int value)
        {
            grid[x, y] = value;  // Aggiorna la cella con il valore specificato.
        }

        // Metodo per ottenere la matrice completa.
        public int[,] GetGrid()
        {
            return grid; // Ritorna la matrice.
        }
    }
}
