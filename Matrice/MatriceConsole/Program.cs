using System;
using Matrice;

namespace MatriceConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            bool errore = false;
            int dimensione = 0;

            do
            {
                try
                {
                    Console.WriteLine("Inserisci la dimensione della matrice (NxN):");
                    dimensione = int.Parse(Console.ReadLine());
                    if (dimensione <= 0)
                    {
                        throw new ArgumentException("La dimensione deve essere un numero positivo.");
                    }
                    errore = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Errore: Inserisci un numero valido.");
                    errore = true;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Errore: {ex.Message}");
                    errore = true;
                }
            } while (errore);

            MatriceClasse matrice = new MatriceClasse(dimensione);
            int[,] elementi = new int[dimensione, dimensione];

            Console.WriteLine("Inserisci gli elementi della matrice:");
            for (int i = 0; i < dimensione; i++)
            {
                for (int j = 0; j < dimensione; j++)
                {
                    do
                    {
                        try
                        {
                            Console.Write($"Elemento [{i},{j}]: ");
                            elementi[i, j] = int.Parse(Console.ReadLine());
                            errore = false;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Errore: Inserisci un numero valido.");
                            errore = true;
                        }
                    } while (errore);
                }
            }

            try
            {
                matrice.RiempireMatrice(elementi);

                bool isDiagonalmenteDominante = matrice.VerificareDiagonalmenteDominante();
                Console.WriteLine($"La matrice è diagonalmente dominante? {isDiagonalmenteDominante}");

                int lunghezzaSequenzaMassima = matrice.CalcolareLunghezzaSequenzaMassima();
                Console.WriteLine($"La lunghezza della sequenza più lunga di numeri uguali consecutivi è: {lunghezzaSequenzaMassima}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore inaspettato: {ex.Message}");
            }
        }
    }
}
