using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VERIFICA_GENNAIO_BOSCHI
{
    public enum TipoProdotto
    {
        Merendina,
        Snacks,
        Bevanda
    }
    public class Prodotto : IComparable<Prodotto>
    {
        public TipoProdotto TipoDiProdotto
        {
            get;
        }
        private string _nomeProdotto;
        public string NomeProdotto
        {
            get
            {
                return _nomeProdotto;
            }
            set
            {
                if (value == null || value == "" || value == " ") throw new ArgumentException("Il nome non può essere ne vuoto ne bianco ne null");
                _nomeProdotto = value;
            }
        }
        //lo faccio in centesimi il prezzo per evitare errori legati all'arrotondamento
        private int _prezzoInCent;
        public int PrezzoInCent
        {
            get
            {
                return _prezzoInCent;
            }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("il prezzo deve essere maggiore di zero");
                _prezzoInCent = value;
            }
        }
        public Prodotto(string nomeProdotto,int prezzoInCent,TipoProdotto tipoDiProdotto)
        {
            PrezzoInCent=prezzoInCent;
            NomeProdotto = nomeProdotto;
            TipoDiProdotto = tipoDiProdotto;
        }

        public int CompareTo(Prodotto? other)
        {
            if(other == null) return 1;
            return PrezzoInCent.CompareTo(other.PrezzoInCent);
        }
    }
}
