using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerificaTeoria_Torneo
{
    public class Partita
    {
        public Giocatore Giocatore1 { get; }
        public Giocatore Giocatore2 { get; }
        public Giocatore? Vincitore { get; }

        public Partita(Giocatore giocatore1, Giocatore giocatore2, Giocatore? vincitore)
        {
            Giocatore1 = giocatore1;
            Giocatore2 = giocatore2;
            Vincitore = vincitore;
        }
    }
}
