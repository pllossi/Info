using Domain.Entities;
using System.Windows;
using Application;

namespace GattileUI
{
    public partial class NewAdoptionWindow : Window
    {
        private ShelterManager manager;

        public NewAdoptionWindow(ShelterManager manager)
        {
            InitializeComponent();
            this.manager = manager;
            cmbCat.ItemsSource = manager.presentCats;
            cmbAdopter.ItemsSource = manager.adopters;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (cmbCat.SelectedItem is Cat cat && cmbAdopter.SelectedItem is Adopter adopter)
            {
                var adoption = new Adoption(adopter, cat, DateTime.Now);
                manager.RegisterAdoption(adoption);
                Close();
            }
            else
            {
                MessageBox.Show("Select both the cat and the adopter.");
            }
        }
    }
}
