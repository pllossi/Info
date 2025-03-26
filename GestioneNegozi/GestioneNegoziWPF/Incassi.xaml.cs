using System;
using System.Windows;
using GestioneNegozi;

namespace GestioneNegoziWPF
{
    public partial class IncassiWindow : Window
    {
        private Negozi _negozi;
        private MainWindow _mainWindow;

        public IncassiWindow(Negozi negozi, MainWindow mainWindow)
        {
            InitializeComponent();
            _negozi = negozi;
            NegozioComboBox.ItemsSource = _negozi.Nomi;
            GiornoComboBox.Items.Clear();
            string[] giorni = new string[7] { "Lunedì", "Martedì", "Mercoledì", "Giovedì", "Venerdì", "Sabato", "Domenica" };
            GiornoComboBox.ItemsSource = giorni;
            _mainWindow = mainWindow;
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
                        _mainWindow.Show();
                        this.Close();
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
