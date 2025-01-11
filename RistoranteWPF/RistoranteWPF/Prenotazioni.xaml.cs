using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RistoranteWPF
{
    /// <summary>
    /// Logica di interazione per Prenotazioni.xaml
    /// </summary>
    public partial class Prenotazioni : Window
    {
        Ristorante ristorante;
        public Prenotazioni(Ristorante r)
        {
            ristorante = r;
            InitializeComponent();
            AggiornaDatiRistorante();
        }
         private void AggiornaDatiRistorante()
        {
            string datiRistorante = $"Ristorante " + ristorante.Nome + "\n" + "Tavoli Prenotati: " + ristorante.TavoliPrenotati + "\n" + "Coperti disponibili: " + ristorante.PostiLiberi;
            lblDatiRistorante.Content = datiRistorante;
        }

        private void DeleteContent(object sender, RoutedEventArgs e)
        {
            //per sicurezza verifico che il sender sia un textbox
            if (sender is TextBox)
            {
                //pulisco il contenuto del testo
                TextBox txtBox = sender as TextBox;
                txtBox.Text = "";
            }
        }

        private void btnPrenota_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int posti = (int)sldNumeroPosti.TickPlacement;
                if (posti > 1 && posti < 5)
                {
                    ristorante.Prenota(posti);
                    AggiornaDatiRistorante();
                }
                else
                {
                    throw new Exception("Il massimo di posti prenotabili devono essere almeno 1 e meno di 5");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore:{ex.Message}", "Errore nella prenotazione");
            }
        }
    }
}
