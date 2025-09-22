using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ramino
{
    /*
    Scrivere la classe Torneo in modo che:
    - alla costruzione del torneo siano creati i giocatori partecipanti e definite il numero dipartite che verranno giocate
    - possano essere inseriti i risultati ottenuti in una certa partita da un certo giocatore
    - possa essere decretato il vincitore del torneo(il giocatore con il punteggio più alto)
    */
    public class Torneo
    {
        public Giocatore[] _giocatori { get; private set; }

        public int NumeroPartite
        {
            get
            {
                return _giocatori[0].NumeroPartite;
            }
        }

        public Torneo(int numeroGiocatori, int numeroPartite)
        {
            _giocatori = new Giocatore[numeroGiocatori];
            for (int i = 0; i < numeroGiocatori; i++)
            {
                _giocatori[i] = new Giocatore(i.ToString(), numeroPartite);
            }
        }

        public Torneo(string[] nomiGiocatori, int numeroPartite)
        {
            _giocatori = new Giocatore[nomiGiocatori.Length];
            int i = 0;
            foreach (string nome in nomiGiocatori)
            {
                _giocatori[i] = new Giocatore(nome, numeroPartite);
                i += 1;
            }
        }

        //vincitore --> il giocatore con il punteggio finale più alto (potrebbero essere più di uno!)



        public void punteggioGiocatoreInPartita(int posizioneGiocatore, int punteggio, int numeroPartita)
        {
            //controlli su posizione
            if (posizioneGiocatore < 0 || posizioneGiocatore > _giocatori.Length) throw new ArgumentOutOfRangeException("La posizione deve essere inclusa nell'array di giocatori");
            //richiamo alla funzione
            _giocatori[posizioneGiocatore].MemorizzaPunteggioPartita(punteggio, numeroPartita);
        }

        public string Vincitore()
        {
            int?[] punteggiGiocatori = new int?[_giocatori.Length];
            for (int i=0; i < _giocatori.Length;i++)
            {
                punteggiGiocatori[i]= _giocatori[_giocatori.Length-1].PunteggioMassimo();
            }
            int punteggioMassimo= 0;
            foreach (int i in punteggiGiocatori)
            {
                if(i > punteggioMassimo) punteggioMassimo = i;
            }
            string vincitore=" ";
            foreach (var i in _giocatori)
            {
                var indice = i.RicercaPartitaPerPunteggio(punteggioMassimo);
                if (indice != null)
                {
                    vincitore = i.Nome;
                }
            }
            return vincitore;
        }

    }
}
