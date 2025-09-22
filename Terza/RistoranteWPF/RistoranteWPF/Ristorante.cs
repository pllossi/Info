using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace RistoranteWPF
{
    public class Ristorante
    {
        private string _nome;
        public string Nome
        {
            get { return _nome; }
        }

        private int _maxCoperti;
        public int MaxCoperti
        {
            get { return _maxCoperti; }
            set
            {
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
        private int[] _postiTavoli;
        public Ristorante(string nome, int tavoliMax)
        {
            _nome = nome;
            MaxCoperti = tavoliMax * 4;
            Tavoli = tavoliMax;
            _postiTavoli = new int[_tavoli];
        }

        public int TavoliLiberi
        {
            get
            {
                int count = 0;
                foreach (int i in _postiTavoli)
                {
                    if (i == null || i == 0)
                        count++;
                }
                return count;
            }
        }

        public int TavoliPrenotati
        {
            get
            {
                return _tavoli - TavoliLiberi;
            }
        }

        public int PostiPrenotati
        {
            get
            {
                int count = 0;
                foreach (int i in _postiTavoli)
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


        public int Prenota(int posti)
        {
            int tavolo = 0;
            bool assegnati = false;
            if (posti > PostiLiberi) throw new Exception("Non abbiamo abbastanza posti");
            for (int i = 0; i < _postiTavoli.Length; i++)
            {
                if ((_postiTavoli[i] == 0 || _postiTavoli[i] == null) && !assegnati)
                {
                    assegnati = true;
                    _postiTavoli[i] = posti;
                    tavolo = i;
                }
            }
            if (!assegnati)
            {
                throw new Exception("I tavoli sono tutti occupati");
            }
            return tavolo;
        }

        public override string ToString()
        {
            return _nome.ToUpper() + " numero massimo coperti: " + MaxCoperti;
        }
    }
}
