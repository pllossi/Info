using Domain.Entities;
using System.Windows;
using Application;
using System.Windows.Media;

namespace GattileUI
{
    public partial class FailedAdoptionWindow : Window
    {
        private ShelterManager manager;

        public FailedAdoptionWindow(ShelterManager manager)
        {
            InitializeComponent();
            this.manager = manager;
            cmbCat.ItemsSource = manager.adoptedCats;
        }

        private void btnRegisterFailed_Click(object sender, RoutedEventArgs e)
        {
            if (cmbCat.SelectedItem is Cat cat && dpStart.SelectedDate.HasValue && dpEnd.SelectedDate.HasValue)
            {
                manager.HandleFailedAdoption(cat, dpStart.SelectedDate.Value, dpEnd.SelectedDate.Value);
                Close();
            }
            else
            {
                MessageBox.Show("Please fill in all fields.");
            }
        }
    }
}
