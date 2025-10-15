using Gattile;
using System.Windows;
using System.ComponentModel;

namespace Gattile
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        GestoreGattile gestore = new GestoreGattile();

        private int _numeroGatti;
        public int NumeroGatti
        {
            get => _numeroGatti;
            set
            {
                if (_numeroGatti != value)
                {
                    _numeroGatti = value;
                    OnPropertyChanged(nameof(NumeroGatti));
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            AggiornaNumeroGatti();
        }

        public void AggiornaNumeroGatti()
        {
            NumeroGatti = gestore.gattiPresenti.Count;
        }

        private void btnVisualizzaGatti_Click(object sender, RoutedEventArgs e)
        {
            var finestra = new FinestraGatti(gestore);
            finestra.Show();
        }

        private void btnNuovoGatto_Click(object sender, RoutedEventArgs e)
        {
            var finestra = new FinestraNuovoGatto(gestore);
            finestra.ShowDialog();
            AggiornaNumeroGatti();
        }

        private void btnVisualizzaAdozioni_Click(object sender, RoutedEventArgs e)
        {
            var finestra = new FinestraAdozioni(gestore);
            finestra.ShowDialog();
        }

        private void btnNuovaAdozione_Click(object sender, RoutedEventArgs e)
        {
            var finestra = new FinestraNuovaAdozione(gestore);
            finestra.ShowDialog();
            AggiornaNumeroGatti();
        }

        private void btnAdozioneFallita_Click(object sender, RoutedEventArgs e)
        {
            var finestra = new FinestraAdozioneFallita(gestore);
            finestra.ShowDialog();
            AggiornaNumeroGatti();
        }

        private void btnNuovoAdottante_Click(object sender, RoutedEventArgs e)
        {
            var finestra = new FinestraNuovoAdottante(gestore);
            finestra.ShowDialog();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
