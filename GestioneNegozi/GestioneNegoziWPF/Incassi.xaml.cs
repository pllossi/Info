using System;
using System.Windows;
using GestioneNegozi;

namespace GestioneNegoziWPF
{
    public partial class IncassiWindow : Window
    {
        private Negozi _negozi;

        public IncassiWindow(Negozi negozi)
        {
            InitializeComponent();
            _negozi = negozi;
            NegozioComboBox.ItemsSource = _negozi.Nomi;
        }

        private void AggiungiIncassi_Click(object sender, RoutedEventArgs e)
        {
            if (_negozi != null)
            {
                int giorno = GiornoComboBox.SelectedIndex;
                string negozio = NegozioComboBox.SelectedItem.ToString();
                double incasso;
                if (double.TryParse(IncassoTextBox.Text, out incasso))
                {
                    try
                    {
                        _negozi.InserisciIncasso(negozio, giorno, incasso);
                        MessageBox.Show("Incasso inserito con successo.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Inserisci un incasso valido.");
                }
            }
            else
            {
                MessageBox.Show("Devi prima inserire i negozi.");
            }
        }
    }
}
