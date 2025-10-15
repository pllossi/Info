using System.Windows;
using GattileLib;

namespace Gattile
{
    public partial class FinestraNuovoAdottante : Window
    {
        private GestoreGattile gestore;

        public FinestraNuovoAdottante(GestoreGattile gestore)
        {
            InitializeComponent();
            this.gestore = gestore;
        }

        private void btnSalva_Click(object sender, RoutedEventArgs e)
        {
        
            try
            {
                if (txtNome.Text == "" || txtCognome.Text == "" || (txtTelefono.Text == "" && txtEmail.Text == ""))
                {
                    throw new ArgumentException();
                }
                var adottante = new Adottante
                {
                    Nome = txtNome.Text,
                    Cognome = txtCognome.Text,
                    Telefono = txtTelefono.Text,
                    Email = txtEmail.Text
                };
                gestore.InserisciAdottante(adottante);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Controlla i campi inseriti.");
            }
            Close();
        }
    }
}
