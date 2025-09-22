using System;

namespace Show
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string titolo = "Concerto";
                DateTime data = DateTime.Now.AddDays(10);
                int nBiglietti = 100;
                double costo = 50.0;
                Spettacolo spettacolo = new Spettacolo(titolo, data, nBiglietti, costo);

                Console.WriteLine($"Spettacolo: {spettacolo.Titolo}");
                Console.WriteLine($"Data: {spettacolo.Data}");
                Console.WriteLine($"Numero di biglietti: {spettacolo.Biglietti.Length}");
                Console.WriteLine($"Costo: {costo}");
                Console.WriteLine("Quale posto si vuole comprare?");

                if (int.TryParse(Console.ReadLine(), out int posto))
                {
                    spettacolo.Vendita(posto);
                    Console.WriteLine($"Biglietto {posto} venduto: {spettacolo.Biglietti[posto - 1].Venduto}");
                }
                else
                {
                    Console.WriteLine("Input non valido.");
                }

                int[] posti = { 2, 3, 4 };
                spettacolo.Vendita(posti);
                foreach (var p in posti)
                {
                    Console.WriteLine($"Biglietto {p} venduto: {spettacolo.Biglietti[p - 1].Venduto}");
                }

                spettacolo.Reso(1);
                Console.WriteLine($"Biglietto 1 reso: {spettacolo.Biglietti[0].Venduto}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
            }
        }
    }
}
