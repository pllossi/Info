using System;
using System.Windows;
using System.Windows.Controls;
using GestioneNegozi;

namespace GestioneNegoziWPF
{
    public partial class NegoziWindow : Window
    {
        private Negozi _negozi;
        private MainWindow _main;

        public NegoziWindow(Negozi negozi, MainWindow main)
        {
            InitializeComponent();
            _negozi = negozi;
            _main = main;
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
                _main.SetNegozi(_negozi);
                _main.Show();
                this.Close();
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
                var statisticheWindow = new StatisticheWindow(_negozi, _main);
                statisticheWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Devi prima inserire i negozi.");
            }
        }
    }
}
