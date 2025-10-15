using System.Windows;

namespace Gattile
{
    public partial class FinestraAdozioni : Window
    {
        public FinestraAdozioni(GestoreGattile gestore)
        {
            InitializeComponent();
            lstAdozioni.ItemsSource = gestore.gattiPresenti.Select(gatto => gatto.Nome).ToList();
            lstAdozioni.SelectionChanged += LstAdozioni_SelectionChanged;
            _gestore = gestore;
        }

        private readonly GestoreGattile _gestore;

        private void LstAdozioni_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (lstAdozioni.SelectedItem is string nomeGatto)
            {
                var gatto = _gestore.gattiPresenti.FirstOrDefault(g => g.Nome == nomeGatto);
                if (gatto != null)
                {
                    var finestraDettagli = new FinestraDettagliGatto(gatto);
                    finestraDettagli.ShowDialog();
                }
            }
        }
    }
}
