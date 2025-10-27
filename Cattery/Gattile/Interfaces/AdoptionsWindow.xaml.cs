using System.Windows;
using System.Xml.Linq;
using Application;

namespace GattileUI
{
    public partial class AdoptionsWindow : Window
    {
        public AdoptionsWindow(ShelterManager manager)
        {
            InitializeComponent();
            lstAdoptions.ItemsSource = manager.presentCats.Select(cat => cat.Name).ToList();
            lstAdoptions.SelectionChanged += LstAdoptions_SelectionChanged;
            _manager = manager;
        }

        private readonly ShelterManager _manager;

        private void LstAdoptions_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (lstAdoptions.SelectedItem is string catName)
            {
                var cat = _manager.presentCats.FirstOrDefault(c => c.Name == catName);
                if (cat != null)
                {
                    var detailsWindow = new CatDetailsWindow(cat);
                    detailsWindow.ShowDialog();
                }
            }
        }
    }
}
