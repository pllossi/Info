using System.Windows;
using System.Windows.Controls;
using NoleggioLib;

namespace Noleggio
{
    public partial class AggiungiVeicolo : Window
    {
        public GestoreNoleggio Gestore { get; set; }
        public AggiungiVeicolo(GestoreNoleggio gestore)
        {
            InitializeComponent();
            Gestore = gestore;
        }

        private void Aggiungi_Click(object sender, RoutedEventArgs e)
        {
            bool errore = false;
            string tipo = (TipoVeicoloCombo.SelectedItem as ComboBoxItem)?.Content.ToString();
            string targa = TargaBox.Text;
            int costo = int.TryParse(CostoBox.Text, out var c) ? c : 0;
            try
            {
                Veicolo v = null;
                if (tipo == "Bicicletta")
                    v = new Bicicletta(targa, costo, DettaglioBox.Text);
                else if (tipo == "Automobile")
                    v = new Automobili(targa, costo, int.Parse(DettaglioBox.Text));
                else if (tipo == "Moto")
                    v = new Moto(targa, costo, DettaglioBox.Text);

                Gestore.AggiungiVeicolo(v);
            }
            catch
            {
                errore = true;
                MessageBox.Show("Errore nei dati inseriti.");
            }
            if(!errore)
            {
                MessageBox.Show("Veicolo aggiunto!");
                this.Close();
            }
        }
    }
}
