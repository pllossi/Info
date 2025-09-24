using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoleggioLib;

namespace Noleggio
{
    public class GestoreNoleggio
    {
        public Veicolo[] veicoliDisponibili = new Veicolo[0];
        public Veicolo[] veicoliNoleggiati = new Veicolo[0];

        public void AggiungiVeicolo(Veicolo v)
        {
            if (veicoliDisponibili == null)
            {
                veicoliDisponibili = new Veicolo[1];
                veicoliDisponibili[0] = v;
            }
            else
            {
                Array.Resize(ref veicoliDisponibili, veicoliDisponibili.Length + 1);
                veicoliDisponibili[veicoliDisponibili.Length - 1] = v;
            }
        }
        public Veicolo NoleggiaBici()
        {
            Veicolo veicolo = null;
            bool trovato = false;
            int count = 0;
            while (!trovato)
            {
                if(veicoliDisponibili[count] is Bicicletta)
                {
                    trovato = true;
                    veicolo = veicoliDisponibili[count];
                }
                else
                {
                    count++;
                }
            }
            veicoliDisponibili[count] = null;
            Array.Resize(ref veicoliNoleggiati, veicoliNoleggiati.Length + 1);
            veicoliNoleggiati[veicoliNoleggiati.Length - 1] = veicolo;
            return veicolo;
        }
        public Veicolo NoleggiaAuto()
        {
            Veicolo veicolo = null;
            bool trovato = false;
            int count = 0;
            while (!trovato)
            {
                if (veicoliDisponibili[count] is Automobili)
                {
                    trovato = true;
                    veicolo = veicoliDisponibili[count];
                }
                else
                {
                    count++;
                }
            }
            veicoliDisponibili[count] = null;
            Array.Resize(ref veicoliNoleggiati, veicoliNoleggiati.Length + 1);
            veicoliNoleggiati[veicoliNoleggiati.Length - 1] = veicolo;
            return veicolo;
        }
        public int RestituisciVeicolo(Veicolo v, DateOnly dataFineNoleggio)
        {
            int costo = v.CalcolaCosto(dataFineNoleggio);
            for (int i = 0; i < veicoliNoleggiati.Length; i++)
            {
                if (veicoliNoleggiati[i] == v)
                {
                    veicoliNoleggiati[i] = null;
                }
            }
            Array.Resize(ref veicoliDisponibili, veicoliDisponibili.Length + 1);
            veicoliDisponibili[veicoliDisponibili.Length - 1] = v;
            return costo;
        }

        public Veicolo NoleggiaMoto()
        {
            Veicolo veicolo = null;
            bool trovato = false;
            int count = 0;
            while (!trovato)
            {
                if (veicoliDisponibili[count] is Moto)
                {
                    trovato = true;
                    veicolo = veicoliDisponibili[count];
                }
                else
                {
                    count++;
                }
            }
            veicoliDisponibili[count] = null;
            Array.Resize(ref veicoliNoleggiati, veicoliNoleggiati.Length + 1);
            veicoliNoleggiati[veicoliNoleggiati.Length - 1] = veicolo;
            return veicolo;
        }
    }
    
}
