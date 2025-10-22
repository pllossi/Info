using GattileUI;
using System.Windows;
using System.ComponentModel;
using Application;

namespace GattileUI
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        ShelterManager manager = new ShelterManager();

        private int _catCount;
        public int CatCount
        {
            get => _catCount;
            set
            {
                if (_catCount != value)
                {
                    _catCount = value;
                    OnPropertyChanged(nameof(CatCount));
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            UpdateCatCount();
        }

        public void UpdateCatCount()
        {
            CatCount = manager.presentCats.Count;
        }

        private void btnViewCats_Click(object sender, RoutedEventArgs e)
        {
            var window = new CatsWindow(manager);
            window.Show();
        }

        private void btnNewCat_Click(object sender, RoutedEventArgs e)
        {
            var window = new NewCatWindow(manager);
            window.ShowDialog();
            UpdateCatCount();
        }

        private void btnViewAdoptions_Click(object sender, RoutedEventArgs e)
        {
            var window = new AdoptionsWindow(manager);
            window.ShowDialog();
        }

        private void btnNewAdoption_Click(object sender, RoutedEventArgs e)
        {
            var window = new NewAdoptionWindow(manager);
            window.ShowDialog();
            UpdateCatCount();
        }

        private void btnFailedAdoption_Click(object sender, RoutedEventArgs e)
        {
            var window = new FailedAdoptionWindow(manager);
            window.ShowDialog();
            UpdateCatCount();
        }

        private void btnNewAdopter_Click(object sender, RoutedEventArgs e)
        {
            var window = new NewAdopterWindow(manager);
            window.ShowDialog();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
