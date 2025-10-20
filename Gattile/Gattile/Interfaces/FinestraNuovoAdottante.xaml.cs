using System.Windows;
using Domain.Entities;
using Domain.ValueObjects;
using Application;

namespace GattileUI
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
                if (string.IsNullOrWhiteSpace(txtNome.Text) || string.IsNullOrWhiteSpace(txtCognome.Text) ||
                    (string.IsNullOrWhiteSpace(txtTelefono.Text) && string.IsNullOrWhiteSpace(txtEmail.Text)))
                {
                    throw new ArgumentException();
                }

                var telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : new PhoneNumber(txtTelefono.Text);
                var email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : new Email(txtEmail.Text);

                var adottante = new Adottante(
                    txtNome.Text,
                    txtCognome.Text,
                    telefono,
                    email
                );

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
