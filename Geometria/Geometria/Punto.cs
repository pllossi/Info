using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    internal class Punto
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        
        //il costruttore si aspetta 2 parametri double, se non viene definito un valore per il parametro viene asseganto 0
        public Punto(double x=0, double y = 0) 
        {
            X = x;
            Y = y;
        }

        public void TraslaX(double x)
        {
            X += x;
        }

        public void TraslaY(double y) { 
            Y += y; 
        }

        public void TraslaXY(double x, double y)
        {
            TraslaX(x);
            TraslaY(y);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is Punto == false) return false;
            Punto punto = obj as Punto;
            if (X == punto.X & Y == punto.Y)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
