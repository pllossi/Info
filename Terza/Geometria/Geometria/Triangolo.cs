using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    internal class Triangolo
    {
        public Segmento Segmento1 {  get; private set; }
        public Segmento Segmento2 { get; private set; }
        public Segmento Segmento3 { get; private set; }
        
        public Triangolo(Segmento segmento1, Segmento segmento2, Segmento segmento3)
        {
            Segmento1 = segmento1;
            Segmento2 = segmento2;
            Segmento3 = segmento3;
            double lunghezzaSegmento1=Segmento1.Lunghezza;
            double lunghezzaSegmento2=Segmento2.Lunghezza;
            double lunghezzaSegmento3=Segmento3.Lunghezza;
           if (lunghezzaSegmento1+lunghezzaSegmento3 > lunghezzaSegmento2 && lunghezzaSegmento1 + lunghezzaSegmento2 > lunghezzaSegmento3 && lunghezzaSegmento2+lunghezzaSegmento3 > lunghezzaSegmento1) {
                if (!(Segmento1.Inizio == Segmento2.Inizio || Segmento2.Inizio == Segmento3.Inizio || Segmento3.Inizio == Segmento1.Inizio) && !(Segmento1.Fine == Segmento2.Fine || Segmento2.Fine == Segmento3.Fine || Segmento3.Fine == Segmento1.Fine) && !(Segmento1.Inizio==Segmento2.Fine||Segmento2.Inizio==Segmento1.Fine||Segmento1.Inizio==Segmento3.Fine||Segmento3.Inizio==Segmento1.Inizio||Segmento2.Inizio==Segmento3.Fine||Segmento3.Inizio==Segmento2.Inizio))
                {
                    throw new Exception("Il triangolo non esiste");
                }
            }
        }
        public double CalcoloPerimetro()
        {
            double perimetro = Segmento1.Lunghezza + Segmento2.Lunghezza + Segmento3.Lunghezza;
            return perimetro;
        }

        public double CalcoloArea()
        { 
            double semiperimetro=CalcoloPerimetro()/2;
            double area = Math.Sqrt(semiperimetro * (semiperimetro - Segmento1.Lunghezza) * (semiperimetro - Segmento2.Lunghezza) * (semiperimetro - Segmento3.Lunghezza));
            return area;
        }

        public void TraslaX(double nuovaX)
        {
            Segmento1.TraslaX(nuovaX);
            Segmento2.TraslaX(nuovaX);
            Segmento3.TraslaX(nuovaX);
        }

        public void TraslaY(double nuovaY)
        {
            Segmento1.TraslaY(nuovaY);
            Segmento2.TraslaY(nuovaY);
            Segmento3.TraslaY(nuovaY);
        }

        public void TraslaXY(double nuovaX, double nuovaY)
        {
            TraslaX(nuovaX);
            TraslaY(nuovaY);
        }
    }
}
