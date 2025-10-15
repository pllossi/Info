using GattileLib;
using System.Windows;

namespace Gattile
{
    public partial class FinestraNuovaAdozione : Window
    {
        private GestoreGattile gestore;

        public FinestraNuovaAdozione(GestoreGattile gestore)
        {
            InitializeComponent();
            this.gestore = gestore;
            cmbGatto.ItemsSource = gestore.gattiPresenti;
            cmbAdottante.ItemsSource = gestore.adottanti; 
        }

        private void btnRegistra_Click(object sender, RoutedEventArgs e)
        {
            if (cmbGatto.SelectedItem is Gatto gatto && cmbAdottante.SelectedItem is Adottante adottante)
            {
                var adozione = new Adozione(adottante, gatto, DateTime.Now);
                gestore.RegistraAdozione(adozione);
                Close();
            }
            else
            {
                MessageBox.Show("Seleziona sia il gatto che l'adottante.");
            }
        }
    }
}
