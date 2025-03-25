using System;
using System.Windows;
using System.Windows.Controls;
using GestioneNegozi;

namespace GestioneNegoziWPF
{
    public partial class NegoziWindow : Window
    {
        private Negozi _negozi;

        public NegoziWindow()
        {
            InitializeComponent();
        }

        private void ConfermaNumeroNegozi_Click(object sender, RoutedEventArgs e)
        {
            int numeroNegozi;
            if (int.TryParse(NumeroNegoziTextBox.Text, out numeroNegozi))
            {
                NegoziItemsControl.Items.Clear();
                for (int i = 0; i < numeroNegozi; i++)
                {
                    NegoziItemsControl.Items.Add(new TextBox());
                }
                NumeroNegoziTextBlock.Text = $"Numero di Negozi: {numeroNegozi}";
            }
            else
            {
                MessageBox.Show("Inserisci un numero valido.");
            }
        }

        private void ConfermaNomiNegozi_Click(object sender, RoutedEventArgs e)
        {
            int numeroNegozi = NegoziItemsControl.Items.Count;
            string[] nomiNegozi = new string[numeroNegozi];

            for (int i = 0; i < numeroNegozi; i++)
            {
                TextBox textBox = (TextBox)NegoziItemsControl.Items[i];
                nomiNegozi[i] = textBox.Text;
            }

            try
            {
                _negozi = new Negozi(numeroNegozi, nomiNegozi);
                MessageBox.Show("Negozi inseriti con successo.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Statistiche_Click(object sender, RoutedEventArgs e)
        {
            if (_negozi != null)
            {
                double? incassoTotale = _negozi.IncassoTotale();
                IncassoTotaleTextBlock.Text = $"Incasso Totale: {incassoTotale}";

                var migliorRisultato = _negozi.MaggiorIncassoPerGiorno();
                MigliorRisultatoTextBlock.Text = $"Miglior Risultato: {string.Join(", ", migliorRisultato.SelectMany(x => x))}";
            }
            else
            {
                MessageBox.Show("Devi prima inserire i negozi.");
            }
        }
    }
}
