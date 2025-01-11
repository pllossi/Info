using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace EsempioWpf
{
    public class Ristorante
    {
        private string _nome;
        public string Nome { 
            get { return _nome; } 
        }

        private int _maxCoperti;
        public int MaxCoperti
        {
            get { return _maxCoperti; }
            set {
                if (value < 0) throw new ArgumentOutOfRangeException();
                _maxCoperti = value; 
            }
        }

        private int _tavoli;
        public int Tavoli
        {
            private set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("il numero di tavoli non può essere negativo");
                _tavoli = value;
            }
            get { return _tavoli; }
        }
        private int[] _tavoliPrenotati;
        public Ristorante(string nome, int tavoliMax)
        {
            _nome = nome;
            MaxCoperti = tavoliMax*4;
            Tavoli = tavoliMax;
            _tavoliPrenotati = new int[_tavoli];
        }

        public int TavoliLiberi
        {
            get
            {
                int count = 0;
                foreach(int i in _tavoliPrenotati)
                {
                    if(i == null||i==0)
                        count++;
                }
                return count;
            }
        }

        public int PostiPrenotati
        {
            get
            {
                int count = 0;
                foreach (int i in _tavoliPrenotati)
                {
                    count += i;
                }
                return count;
            }
        }

        public int PostiLiberi
        {
            get
            {
                return MaxCoperti - PostiPrenotati;
            }
        }


        public void Prenota(int posti)
        {
            bool assegnati=false;
            if (posti > PostiLiberi) throw new Exception("Non abbiamo abbastanza posti");
            for (int i = 0; i < _tavoliPrenotati.Length; i++)
            {
                if((_tavoliPrenotati[i] == 0 || _tavoliPrenotati[i] == null)&&!assegnati)
                {
                    assegnati=true;
                    _tavoliPrenotati[i] = posti;
                }
            }
            if (!assegnati)
            {
                throw new Exception("I tavoli sono tutti occupati");
            }
        }

        public override string ToString()
        {
            return _nome.ToUpper() + " numero massimo coperti: " + MaxCoperti;
        }
    }
}
