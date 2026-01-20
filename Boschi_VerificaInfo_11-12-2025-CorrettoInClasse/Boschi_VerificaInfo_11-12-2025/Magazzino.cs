using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Boschi_VerificaInfo_11_12_2025
{
    public class Magazzino
    {
        private Dictionary<Prodotto, int> inventario;

        private PriorityQueue<Ordine, Ordine> codaOrdini;

        public Magazzino()
        {
            inventario = new Dictionary<Prodotto, int>();

            codaOrdini = new PriorityQueue<Ordine, Ordine>(new Riordinatore());
        }

        public void InserisciProdotto(Prodotto p, int quantita)
        {
            if (inventario.ContainsKey(p))
                inventario[p] += quantita;
            else
                inventario[p] = quantita;
        }

        public void InserisciOrdine(Ordine o)
        {
            codaOrdini.Enqueue(o,o);
        }

        public Ordine? ElaboraOrdine()
        {
            if (codaOrdini.Count == 0)
            {
                Console.WriteLine("Nessun ordine in attesa.");
                return null;
            }

            Ordine ordine = codaOrdini.Dequeue();

            foreach (var item in ordine.Prodotti)
            {
                Prodotto p = item.Key;
                int quantita = item.Value;
                

                if (!inventario.ContainsKey(p) || inventario[p] < quantita)
                {
                    Console.WriteLine($"Ordine {ordine.Id} NON processato: prodotto {p.Nome} non disponibile.");
                    return null;
                }
            }

            foreach (var item in ordine.Prodotti)
            {
                Prodotto p = item.Key;
                int quantita = item.Value;
                inventario[p] -= quantita;
            }

            return ordine;
        }
    }

}
