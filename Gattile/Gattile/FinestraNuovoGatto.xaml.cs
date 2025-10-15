using GattileLib;
using System.Windows;

namespace Gattile
{
    public partial class FinestraNuovoGatto : Window
    {
        private GestoreGattile gestore;

        public FinestraNuovoGatto(GestoreGattile gestore)
        {
            InitializeComponent();
            this.gestore = gestore;
        }

        private void btnSalva_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(txtNome.Text == "" || txtRazza.Text == "" || !dpDataNascita.SelectedDate.HasValue)
                {
                    throw new ArgumentException();
                }
                var nuovoGatto = new Gatto(
                    txtNome.Text,
                    txtRazza.Text,
                    chkMaschio.IsChecked == true,
                    txtDescrizione.Text,
                    null,
                    dpDataNascita.SelectedDate
                );
                gestore.InserisciGatto(nuovoGatto);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Controlla i campi inseriti.");
            }
            Close();
        }
    }
}
