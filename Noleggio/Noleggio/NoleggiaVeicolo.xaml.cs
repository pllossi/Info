using System.Windows;
using System.Windows.Controls;
using NoleggioLib;

namespace Noleggio
{
    public partial class NoleggiaVeicolo : Window
    {
        public GestoreNoleggio Gestore { get; set; }
        public NoleggiaVeicolo(GestoreNoleggio gestore)
        {
            InitializeComponent();
            Gestore = gestore;
        }

        private void Noleggia_Click(object sender, RoutedEventArgs e)
        {
            string tipo = (TipoVeicoloCombo.SelectedItem as ComboBoxItem)?.Content.ToString();
            DateOnly dataInizio = DateOnly.FromDateTime(DataInizioPicker.SelectedDate ?? System.DateTime.Now);
            Veicolo v = null;
            if (tipo == "Bicicletta")
                v = Gestore.NoleggiaBici();
            else if (tipo == "Automobile")
                v = Gestore.NoleggiaAuto();
            else if (tipo == "Moto")
                v = Gestore.NoleggiaMoto();

            if (v != null)
            {
                v.GetType().GetMethod("InizioNoleggio")?.Invoke(v, new object[] { dataInizio });
                MessageBox.Show("Veicolo noleggiato!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Nessun veicolo disponibile.");
            }
        }
    }
}
