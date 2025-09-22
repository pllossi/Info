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

namespace VERIFICA_APRILE_BOSCHI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameLogic partita;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Button)
            {
                int coordX = 0;
                int coordY = 0;
                Button button = (Button)sender;
                switch (button.Name)
                {
                    case "c0r0":
                        coordX=0; coordY=0;
                        break;
                    case "c0r1":
                        coordX=0; coordY=1;
                        break;
                    case "c0r2":
                        coordX=0; coordY=2;
                        break;
                    case "c0r3":
                        coordX=0; coordY=3;
                        break;
                    case "c0r4":
                        coordX=0; coordY=4;
                        break;
                    case "c1r0":
                        coordX=1; coordY=0;
                        break;
                    case "c1r1":
                        coordX=1; coordY=1;
                        break;
                    case "c1r2":
                        coordX=1; coordY=2;
                        break;
                    case "c1r3":
                        coordX=1; coordY=3;
                        break;
                    case "c1r4":
                        coordX=1; coordY=4;
                        break;
                    case "c2r0":
                        coordX=2; coordY=0;
                        break;
                    case "c2r1":
                        coordX=2; coordY=1;
                        break;
                    case "c2r2":
                        coordX=2; coordY=2;
                        break;
                    case "c2r3":
                        coordX=2; coordY=3;
                        break;
                    case "c2r4":
                        coordX=2; coordY=4;
                        break;
                    case "c3r0":
                        coordX=3; coordY=0;
                        break;
                    case "c3r1":
                        coordX=3; coordY=1;
                        break;
                    case "c3r2":
                        coordX=3; coordY=2;
                        break;
                    case "c3r3":
                        coordX=3; coordY=3;
                        break;
                    case "c3r4":
                        coordX=3; coordY=4;
                        break;

                }
                if (partita.Tentativo(coordX, coordY))
                {
                    MessageBox.Show($"Hai vinto in {partita.NumeroTentativiFatti}");
                    grdCampoDaGioco.Visibility = Visibility.Hidden;
                    btnInizioPartita.Visibility = Visibility.Visible;
                }
                else
                {
                    button.Content = "X";
                }
            }
        }

        private void btnInizioPartita_Click(object sender, RoutedEventArgs e)
        {
            partita = new GameLogic(5);
            btnInizioPartita.Visibility = Visibility.Hidden;
            grdCampoDaGioco.Visibility = Visibility.Visible;
        }
    }
}