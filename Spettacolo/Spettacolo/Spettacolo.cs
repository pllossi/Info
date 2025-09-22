using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Show
{
    public class Spettacolo
    {
        public Biglietto[] Biglietti { get; private set; }
        private string _titolo;
        private DateTime _data;
        public string Titolo { 
            get { return _titolo; }
            private set {
                if(value.Length > 0)
                    _titolo = value;
                else
                    throw new System.Exception("Titolo non valido");
            }
        }
        public DateTime Data { 
            get { return _data; }
            private set {
                if(value > DateTime.Now)
                    _data = value;
                else
                     throw new System.Exception("Data non valida");
            }
        }
        public Spettacolo(string titolo,DateTime data,int nBiglietti,double costo)
        {
            Titolo = titolo;
            Data = data;
            Biglietti = new Biglietto[nBiglietti];
            for(int i = 0; i < nBiglietti; i++)
                Biglietti[i] = new Biglietto(costo,i+1);
        }
        public void Vendita(int posto)
        {
            Biglietti[posto-1].Vendita();
        }
        public void Vendita()
        {
            var random = new Random().Next(1, Biglietti.Length);
            while(Biglietti[random].Venduto)
            {
                random = new Random().Next(1, Biglietti.Length);
            }
            Biglietti[random].Vendita();
        }
        public void Vendita(int[] posti)
        {
            foreach(var posto in posti)
                Biglietti[posto-1].Vendita();
        }
        public void Reso(int posto)
        {
            Biglietti[posto-1].Reso();
        }
    }
}
