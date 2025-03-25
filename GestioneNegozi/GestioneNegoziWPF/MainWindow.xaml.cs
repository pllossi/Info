using GestioneNegozi;
using System.Windows;

namespace GestioneNegoziWPF
{
    public partial class MainWindow : Window
    {
        private Negozi _negozi;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ApriNegozi_Click(object sender, RoutedEventArgs e)
        {
            var negoziWindow = new NegoziWindow();
            negoziWindow.Show();
        }

        private void ApriIncassi_Click(object sender, RoutedEventArgs e)
        {
            if (_negozi != null)
            {
                var incassiWindow = new IncassiWindow(_negozi);
                incassiWindow.Show();
            }
            else
            {
                MessageBox.Show("Devi prima inserire i negozi.");
            }
        }

        private void ApriStatistiche_Click(object sender, RoutedEventArgs e)
        {
            if (_negozi != null)
            {
                var statisticheWindow = new StatisticheWindow(_negozi);
                statisticheWindow.Show();
            }
            else
            {
                MessageBox.Show("Devi prima inserire i negozi.");
            }
        }
    }
}
