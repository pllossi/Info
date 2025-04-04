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
        public int Numero { get; }

        public Partita(Giocatore giocatore1, Giocatore giocatore2, Giocatore? vincitore, int numero)
        {
            if(giocatore1 == null) throw new ArgumentNullException(nameof(giocatore1), "Il giocatore 1 non può essere null");
            if (giocatore2 == null) throw new ArgumentNullException(nameof(giocatore2), "Il giocatore 2 non può essere null");
            if (numero < 0) throw new ArgumentOutOfRangeException(nameof(numero), "Il numero della partita deve essere maggiore o uguale a 0");
            if(giocatore1.Numero == giocatore2.Numero) throw new ArgumentException("I due giocatori non possono essere gli stessi", nameof(giocatore2));
            if (vincitore != null && vincitore.Numero != giocatore1.Numero && vincitore.Numero != giocatore2.Numero)
                throw new ArgumentException("Il vincitore deve essere uno dei due giocatori", nameof(vincitore));
            Giocatore1 = giocatore1;
            Giocatore2 = giocatore2;
            Vincitore = vincitore;
            Numero = numero;
        }
    }
}
