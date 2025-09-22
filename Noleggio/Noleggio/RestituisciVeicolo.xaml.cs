using System.Windows;
using NoleggioLib;

namespace Noleggio
{
    public partial class RestituisciVeicolo : Window
    {
        public GestoreNoleggio Gestore { get; set; }
        public RestituisciVeicolo(GestoreNoleggio gestore)
        {
            InitializeComponent();
            Gestore = gestore;
        }

        private void Restituisci_Click(object sender, RoutedEventArgs e)
        {
            string targa = TargaBox.Text;
            DateOnly dataFine = DateOnly.FromDateTime(DataFinePicker.SelectedDate ?? System.DateTime.Now);
            Veicolo v = Gestore.veicoliNoleggiati?.FirstOrDefault(x => x != null && x.targa == targa);
            if (v != null)
            {
                int costo = Gestore.RestituisciVeicolo(v, dataFine);
                MessageBox.Show($"Veicolo restituito! Costo: {costo}€");
                this.Close();
            }
            else
            {
                MessageBox.Show("Veicolo non trovato tra quelli noleggiati.");
            }
        }
    }
}
