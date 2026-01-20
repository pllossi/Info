using System;

namespace Boschi_VerificaInfo_11_12_2025
{
    internal static class Program
    {
        public static void Main()
        {
            Magazzino m = new Magazzino();

            Prodotto p1 = new Prodotto(1, "Monitor", 150);
            Prodotto p2 = new Prodotto(2, "Mouse", 20);

            m.InserisciProdotto(p1, 10);
            m.InserisciProdotto(p2, 50);

            Dictionary<Prodotto,int> ord1 = new Dictionary<Prodotto,int>();
            ord1.Add(p1, 1);
            Ordine o1 = new Ordine(100, "Mario", "Solo Pomeriggio", ord1, false);

            Dictionary<Prodotto,int> ord2 = new Dictionary<Prodotto,int>();
            ord2.Add(p2, 2);
            Ordine o2 = new Ordine(101, "Luigi Bianchi","mattina solo",ord2,true);

            m.InserisciOrdine(o1);
            m.InserisciOrdine(o2);

            var ordElab1 = m.ElaboraOrdine();// Elabora PRIMA quello urgente
            Console.WriteLine(ordElab1);
            var ordElab2 = m.ElaboraOrdine(); // Poi quello normale
            Console.WriteLine(ordElab2);
        }
    }

}