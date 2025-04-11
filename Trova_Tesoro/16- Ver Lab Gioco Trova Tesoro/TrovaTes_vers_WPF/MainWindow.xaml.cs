using System.Windows; // Importa il namespace per gestire la grafica in WPF.
using System.Windows.Controls; // Importa il namespace per i controlli GUI come i pulsanti.

namespace TreasureHuntGame // Definisce il namespace del progetto.
{
    public partial class MainWindow : Window // Classe principale della finestra.
    {
        private GameLogic gameLogic; // Istanza di GameLogic per la logica del gioco.
        private GridManager gridManager; // Istanza di GridManager per gestire la griglia.
        private Player player; // Istanza di Player per tenere traccia delle mosse del giocatore.

        public MainWindow() // Costruttore della finestra principale.
        {
            InitializeComponent(); // Inizializza i componenti grafici.
            gameLogic = new GameLogic(); // Inizializza l'oggetto GameLogic.
            gridManager = new GridManager(5, 5); // Crea una griglia di dimensione 5x5.
            player = new Player(); // Inizializza l'oggetto Player.
            SetupGrid(); // Metodo per configurare la griglia grafica.
        }

        private void SetupGrid() // Metodo per configurare la griglia grafica.
        {
            for (int i = 0; i < 5; i++) // Itera per ogni riga della griglia.
            {
                GameGrid.ColumnDefinitions.Add(new ColumnDefinition());
                for (int j = 0; j < 5; j++) // Itera per ogni colonna della griglia.
                {
                    GameGrid.RowDefinitions.Add(new RowDefinition());
                    Button btn = new Button // Crea un nuovo pulsante per rappresentare una cella.
                    {
                        Content = "", // Imposta il contenuto iniziale del pulsante.
                        Tag = (i, j) // Memorizza la posizione della cella nelle proprietà del pulsante.
                    };
                    btn.Click += OnCellClick; // Associa l'evento di click al pulsante.
                    GameGrid.Children.Add(btn); // Aggiunge il pulsante alla griglia grafica.
                    
                }
            }
        }

        private void OnCellClick(object sender, RoutedEventArgs e) // Metodo per gestire il click su una cella.
        {
            Button clickedButton = (Button)sender; // Identifica il pulsante cliccato.
            var (x, y) = ((int, int))clickedButton.Tag; // Recupera le coordinate della cella cliccata.

            player.IncrementMoves(); // Incrementa il numero di mosse del giocatore.

            if (gameLogic.IsTreasureFound(x, y)) // Controlla se il tesoro è stato trovato.
            {
                clickedButton.Content = "🎉"; // Aggiorna la cella con un'icona di successo.
                MessageBox.Show("Tesoro trovato in " + player.Moves + " mosse!"); // Mostra un messaggio di vittoria.
            }
            else
            {
                clickedButton.Content = "❌"; // Aggiorna la cella con un'icona di tentativo fallito.
            }
        }
    }
}

