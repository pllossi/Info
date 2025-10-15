using GattileLib;
using System;
using System.Windows;

namespace Gattile
{
    /// <summary>
    /// Logica di interazione per FinestraDettagliGatto.xaml
    /// </summary>
    public partial class FinestraDettagliGatto : Window
    {
        public FinestraDettagliGatto(Gatto gatto)
        {
            InitializeComponent();
            DataContext = new GattoDettagliViewModel(gatto);
        }

        private void BtnChiudi_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

    public class GattoDettagliViewModel
    {
        public string Nome { get; }
        public string Razza { get; }
        public string Sesso { get; }
        public DateTime? DataNascita { get; }
        public string? Descrizione { get; }
        public string CodiceIdentificativo { get; }

        public GattoDettagliViewModel(Gatto gatto)
        {
            Nome = gatto.Nome;
            Razza = gatto.Razza;
            Sesso = gatto.Maschio ? "Maschio" : "Femmina";
            DataNascita = gatto.DataNascita;
            Descrizione = gatto.Descrizione;
            CodiceIdentificativo = gatto.CodiceId;
        }
    }
}
