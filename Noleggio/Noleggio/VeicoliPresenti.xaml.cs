using System.Windows;
using System.Linq;

namespace Noleggio
{
    public partial class VeicoliPresenti : Window
    {
        private GestoreNoleggio gestore;

        public VeicoliPresenti(GestoreNoleggio gestore)
        {
            InitializeComponent();
            this.gestore = gestore;
            CaricaVeicoli();
        }

        private void CaricaVeicoli()
        {
            VeicoliListBox.Items.Clear();

            if (gestore.veicoliDisponibili != null && gestore.veicoliDisponibili.Length > 0)
            {
                foreach (var v in gestore.veicoliDisponibili.Where(x => x != null))
                {
                    VeicoliListBox.Items.Add($"Disponibile - {v}");
                }
            }

            if (gestore.veicoliNoleggiati != null && gestore.veicoliNoleggiati.Length > 0)
            {
                foreach (var v in gestore.veicoliNoleggiati.Where(x => x != null))
                {
                    VeicoliListBox.Items.Add($"Noleggiato - {v}");
                }
            }
        }
    }
}
