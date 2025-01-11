using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RistoranteWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnEsempio_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //recupero il nome dal textbox
                string nome = txtNome.Text;
                //recuperare il numero di coperti dal textbox
                int nCoperti = int.Parse(txtCoperti.Text);

                //creare l'oggetto ristorante
                Ristorante ristorante = new Ristorante(nome, nCoperti);

                //cambio la label
                lblRistorante.Content = ristorante;

                /*
                //disabilito il bottone
                btnEsempio.IsEnabled = false;
                //disabilito anche i textbox
                txtNome.IsEnabled = false;
                txtCoperti.IsEnabled = false;
                //così rendo invisibile il bottone
                //btnEsempio.Visibility = Visibility.Hidden;
                */

                //istanzio la finestra delle prenotazioni
                Prenotazioni finestraPrenotazioni = new Prenotazioni(ristorante);
                //impsto la finestra delle prenotazioni
                finestraPrenotazioni.Show();

                this.Close();

            }
            catch (Exception ex)
            {
                //se c'è un errore mostro all'utente un messaggio 
                MessageBox.Show($"Errore:{ex.Message}", "Errore nella creazione del ristorante");
            }
        }

        //siccome il comportamento deve essere lo stesso per entrambi i campi di testo, entrambi richiamano lo stesso metodo
        //nello xaml dei due textbox ho inserito GotFocus="DeleteContent"
        private void DeleteContent(object sender, RoutedEventArgs e)
        {
            //per sicurezza verifico che il sender sia un textbox
            if (sender is TextBox)
            {
                //pulisco il contenuto del testo
                TextBox txtBox = sender as TextBox;
                txtBox.Text = "";
            }
            else
            {
                if (sender is Button)
                {
                    txtCoperti.Text = "";
                    txtNome.Text = "";
                }
            }
        }

    }
}