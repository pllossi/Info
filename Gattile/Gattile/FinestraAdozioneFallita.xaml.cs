using GattileLib;
using System.Windows;

namespace Gattile
{
    public partial class FinestraAdozioneFallita : Window
    {
        private GestoreGattile gestore;

        public FinestraAdozioneFallita(GestoreGattile gestore)
        {
            InitializeComponent();
            this.gestore = gestore;
            cmbGatto.ItemsSource = gestore.gattiAdottati;
        }

        private void btnRegistraFallita_Click(object sender, RoutedEventArgs e)
        {
            if (cmbGatto.SelectedItem is Gatto gatto && dpInizio.SelectedDate.HasValue && dpTermine.SelectedDate.HasValue)
            {
                gestore.GestisciAdozioneFallita(gatto, dpInizio.SelectedDate.Value, dpTermine.SelectedDate.Value);
                Close();
            }
            else
            {
                MessageBox.Show("Compila tutti i campi.");
            }
        }
    }
}
