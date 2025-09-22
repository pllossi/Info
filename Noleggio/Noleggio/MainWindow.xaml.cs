using System.Windows;

namespace Noleggio
{
    public partial class MainWindow : Window
    {
        private GestoreNoleggio gestore = new GestoreNoleggio();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AggiungiVeicolo_Click(object sender, RoutedEventArgs e)
        {
            var win = new AggiungiVeicolo(gestore);
            win.ShowDialog();
        }

        private void NoleggiaVeicolo_Click(object sender, RoutedEventArgs e)
        {
            var win = new NoleggiaVeicolo(gestore);
            win.ShowDialog();
        }

        private void RestituisciVeicolo_Click(object sender, RoutedEventArgs e)
        {
            var win = new RestituisciVeicolo(gestore);
            win.ShowDialog();
        }
        private void VeicoliPresenti_Click(object sender, RoutedEventArgs e)
        {
            var win = new VeicoliPresenti(gestore);
            win.ShowDialog();
        }
    }
}
