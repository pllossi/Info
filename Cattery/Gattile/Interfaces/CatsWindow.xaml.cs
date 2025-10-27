using Domain.Entities;
using System.Linq;
using System.Windows;
using Application;

namespace GattileUI
{
    public partial class CatsWindow : Window
    {
        private ShelterManager manager;

        public CatsWindow(ShelterManager manager)
        {
            InitializeComponent();
            this.manager = manager;
            UpdateCatsList();
        }

        private void UpdateCatsList()
        {
            // Show both present and adopted cats
            lstCats.ItemsSource = null;
            lstCats.ItemsSource = manager.presentCats.Concat(manager.adoptedCats).ToList();
        }

        private void lstCats_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (lstCats.SelectedItem is Cat cat)
            {
                string info = $"Name: {cat.Name}\n" +
                              $"Breed: {cat.Breed}\n" +
                              $"Male: {(cat.Male ? "Yes" : "No")}\n" +
                              $"Description: {cat.Description}\n" +
                              $"Birth date: {cat.BirthDate?.ToShortDateString() ?? "N/A"}\n" +
                              $"Arrival date: {cat.ShelterArrivalDate.ToShortDateString()}\n" +
                              $"Exit date: {cat.ExitDate?.ToShortDateString() ?? "Still present"}\n" +
                              $"Code ID: {cat.CodeId}";
                MessageBox.Show(info, "Cat Details", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
