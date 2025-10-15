using GattileLib;
using System.Linq;
using System.Windows;

namespace Gattile
{
    public partial class FinestraGatti : Window
    {
        private GestoreGattile gestore;

        public FinestraGatti(GestoreGattile gestore)
        {
            InitializeComponent();
            this.gestore = gestore;
            AggiornaListaGatti();
        }

        private void AggiornaListaGatti()
        {
            // Mostra sia i gatti presenti che quelli adottati
            lstGatti.ItemsSource = null;
            lstGatti.ItemsSource = gestore.gattiPresenti.Concat(gestore.gattiAdottati).ToList();
        }

        private void lstGatti_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (lstGatti.SelectedItem is Gatto gatto)
            {
                string info = $"Nome: {gatto.Nome}\n" +
                              $"Razza: {gatto.Razza}\n" +
                              $"Maschio: {(gatto.Maschio ? "Sì" : "No")}\n" +
                              $"Descrizione: {gatto.Descrizione}\n" +
                              $"Data di nascita: {gatto.DataNascita?.ToShortDateString() ?? "N/D"}\n" +
                              $"Data arrivo: {gatto.DataArrivoGattile.ToShortDateString()}\n" +
                              $"Data uscita: {gatto.DataUscita?.ToShortDateString() ?? "Ancora presente"}\n" +
                              $"Codice ID: {gatto.CodiceId}";
                MessageBox.Show(info, "Dettagli Gatto", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
