using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsempioWpf
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
                if (value < 0) throw new Exception("errore");
                _maxCoperti = value;
            }
        }
        public Ristorante(string nome, int coperti)
        {
            _nome = nome;
            MaxCoperti = coperti;
        }

        public override string ToString()
        {
            return "RISTORANTE " + _nome.ToUpper() + "numero massimo coperti: " + MaxCoperti;
        }
    }
}
