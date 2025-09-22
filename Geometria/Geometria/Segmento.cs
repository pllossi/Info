using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    internal class Segmento
    {
        public Punto Inizio { private set; get; }
        public Punto Fine { private set; get; }
        public double Lunghezza { private set; get; }
        public Segmento(Punto punto1, Punto punto2)
        {
            if (punto1.Equals(punto2)==false)
            {
                throw new ArgumentException("I due punti sono uguali");  
            }
            
            if (punto1.X > punto2.X)
            {
                Inizio = punto1;
                Fine = punto2;
            } else
            {
                Fine = punto1;
                Inizio = punto2;
            }
            
            CalcolaLunghezza();
        }

        private void CalcolaLunghezza()
        {
            double x = Math.Abs(Inizio.X - Fine.X);
            double y = Math.Abs(Inizio.Y - Fine.Y);
            Lunghezza = Math.Sqrt(x*x+y*y);
        }

        public void TraslaXY(double nuovaX, double nuovaY)
        {
            TraslaX(nuovaX);
            TraslaY(nuovaY);
            CalcolaLunghezza();
        }

        public void TraslaX(double nuovaX)
        {
            Inizio.TraslaX(nuovaX);
            Fine.TraslaX(nuovaX);
        }

        public void TraslaY(double nuovaY)
        {
            Inizio.TraslaY(nuovaY);
            Fine .TraslaY(nuovaY);
        }

        
    }
}
