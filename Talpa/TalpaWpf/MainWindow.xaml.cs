using System;
using System.Windows;
using System.Windows.Controls;
using Talpa;

namespace TalpaWpf
{
    public partial class MainWindow : Window
    {
        private CampoDaGioco campoDaGioco;
        private int tentativi;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreaCampo_Click(object sender, RoutedEventArgs e)
        {
            int WindowWidth = (int)Application.Current.MainWindow.Width;
            int WindowHeight = (int)Application.Current.MainWindow.Height;
            int dimensioneMinimaPulsanti = 100;
            int numeroMassimoPulsanti = WindowHeight* WindowWidth / (dimensioneMinimaPulsanti * dimensioneMinimaPulsanti);
            if (int.TryParse(NumeroTentativi.Text, out int tent) && int.TryParse(DimensioneTextBox.Text, out int dimensione))
            {
                tentativi = tent;
                try
                {
                    if (dimensione <=1 || dimensione >= numeroMassimoPulsanti) throw new Exception("La dimensione del campo deve essere abbastanza piccola per vedere i pulsanti");
                    campoDaGioco = new CampoDaGioco(dimensione, tentativi);
                    GeneraCampo(dimensione);
                    RigiocaButton.Visibility = Visibility.Collapsed;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Inserisci una dimensione valida.");
            }
        }

        private void GeneraCampo(int dimensione)
        {
            CampoGrid.Children.Clear();
            CampoGrid.RowDefinitions.Clear();
            CampoGrid.ColumnDefinitions.Clear();

            for (int i = 0; i < dimensione; i++)
            {
                CampoGrid.RowDefinitions.Add(new RowDefinition());
                CampoGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 0; i < dimensione; i++)
            {
                for (int j = 0; j < dimensione; j++)
                {
                    Button button = new Button
                    {
                        Content = "",
                        Tag = (i, j)
                    };
                    button.Click += Button_Click;
                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);
                    CampoGrid.Children.Add(button);
                }
            }
            Random coord = new Random();
            campoDaGioco.PosizionaTalpa(coord.Next(0, dimensione), coord.Next(0, dimensione));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is (int x, int y))
            {
                bool trovato = campoDaGioco.Tentativo(x, y);
                if (trovato)
                {
                    CampoGrid.Children.Clear();
                    MessageBox.Show($"Hai vinto! Talpa trovata in {x},{y} in {campoDaGioco.GetTentativi()} tentativi!");
                    RigiocaButton.Visibility = Visibility.Visible;
                }
                else
                {
                    button.Content = "X";
                    MessageBox.Show($"Nessuna talpa in {x},{y}. Tentativi: {campoDaGioco.GetTentativi()}");
                    button.IsEnabled = false;
                    if (campoDaGioco.GetTentativiRimanenti()==0)
                    {
                        CampoGrid.Children.Clear();
                        RigiocaButton.Visibility = Visibility.Visible;
                        MessageBox.Show("Hai Finito i tentativi,Hai perso");
                    }
                }
            }
        }

        private void Rigioca_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(DimensioneTextBox.Text, out int dimensione))
            {
                campoDaGioco = new CampoDaGioco(dimensione,tentativi);
                GeneraCampo(dimensione);
                RigiocaButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show("Inserisci una dimensione valida.");
            }
        }
    }
}
