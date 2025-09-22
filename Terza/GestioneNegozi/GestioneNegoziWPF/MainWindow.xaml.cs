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

        public void SetNegozi(Negozi negozi)
        {
            _negozi = negozi;
        }

        private void ApriNegozi_Click(object sender, RoutedEventArgs e)
        {
            var negoziWindow = new NegoziWindow(_negozi, this);
            negoziWindow.Show();
            this.Hide();
        }

        private void ApriIncassi_Click(object sender, RoutedEventArgs e)
        {
            if (_negozi != null)
            {
                var incassiWindow = new IncassiWindow(_negozi, this);
                incassiWindow.Show();
                this.Hide();
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
                var statisticheWindow = new StatisticheWindow(_negozi, this);
                statisticheWindow.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Devi prima inserire i negozi.");
            }
        }
    }
}
