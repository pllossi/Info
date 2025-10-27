using Domain.Entities;
using Domain.ValueObjects;
using System.Windows;
using Application;

namespace GattileUI
{
    public partial class NewCatWindow : Window
    {
        private ShelterManager manager;

        public NewCatWindow(ShelterManager manager)
        {
            InitializeComponent();
            this.manager = manager;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtName.Text == "" || txtBreed.Text == "" || !dpBirthDate.SelectedDate.HasValue)
                {
                    throw new ArgumentException();
                }
                var newCat = new Cat(
                    txtName.Text,
                    txtBreed.Text,
                    chkMale.IsChecked == true,
                    txtDescription.Text,
                    null,
                    dpBirthDate.SelectedDate
                );
                manager.AddCat(newCat);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Check the entered fields.");
            }
            Close();
        }
    }
}
