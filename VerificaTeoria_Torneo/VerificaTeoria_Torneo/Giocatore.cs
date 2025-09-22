using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerificaTeoria_Torneo
{
    public class Giocatore
    {
        public int Numero { get; private set; }
        public string Nome { get; set; }
        public DateTime DataIscrizione { get; set; }
        public int PunteggioMassimo { get; set; }

        public Giocatore(string nome, DateTime dataIscrizione, int punteggioMassimo, int numero)
        {
            Numero = numero;
            Nome = nome;
            DataIscrizione = dataIscrizione;
            PunteggioMassimo = punteggioMassimo;
        }
    }
}
