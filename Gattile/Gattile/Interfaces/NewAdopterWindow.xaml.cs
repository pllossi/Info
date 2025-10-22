using System.Windows;
using Domain.Entities;
using Domain.ValueObjects;
using Application;
using System.Xml.Linq;

namespace GattileUI
{
    public partial class NewAdopterWindow : Window
    {
        private ShelterManager manager;

        public NewAdopterWindow(ShelterManager manager)
        {
            InitializeComponent();
            this.manager = manager;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtSurname.Text) ||
                    (string.IsNullOrWhiteSpace(txtPhone.Text) && string.IsNullOrWhiteSpace(txtEmail.Text)))
                {
                    throw new ArgumentException();
                }

                var phone = string.IsNullOrWhiteSpace(txtPhone.Text) ? null : new PhoneNumber(txtPhone.Text);
                var email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : new Email(txtEmail.Text);

                var adopter = new Adopter(
                    txtName.Text,
                    txtSurname.Text,
                    phone,
                    email
                );

                manager.AddAdopter(adopter);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Check the entered fields.");
            }
            Close();
        }
    }
}
