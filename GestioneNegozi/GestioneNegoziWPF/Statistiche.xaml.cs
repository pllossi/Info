using System;
using System.Windows;
using GestioneNegozi;

namespace GestioneNegoziWPF
{
    public partial class StatisticheWindow : Window
    {
        private Negozi _negozi;

        public StatisticheWindow(Negozi negozi)
        {
            InitializeComponent();
            _negozi = negozi;
            NegozioComboBox.ItemsSource = _negozi.Nomi;
        }

        private void VisualizzaStatistiche_Click(object sender, RoutedEventArgs e)
        {
            if (_negozi != null)
            {
                string negozio = NegozioComboBox.SelectedItem.ToString();
                double? incassoTotale = _negozi.IncassoTotalePerNegozio(negozio);
                double? incassoMedio = _negozi.IncassoMedioPerNegozio(negozio);
                string[] giorniChiusura = _negozi.GiornoDiChiusura(negozio);

                IncassoTotaleTextBlock.Text = $"Incasso Totale: {incassoTotale}";
                IncassoMedioTextBlock.Text = $"Incasso Medio: {incassoMedio}";
                GiorniChiusuraTextBlock.Text = $"Giorni di Chiusura: {string.Join(", ", giorniChiusura)}";
            }
            else
            {
                MessageBox.Show("Devi prima inserire i negozi.");
            }
        }
    }
}
