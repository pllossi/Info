using Atleta;
using System;

class Program
{
    static void Main(string[] args)
    {
        string nome = string.Empty;
        string cognome = string.Empty;
        int nDiscipline = 0;
        bool errore = true;

        while (errore)
        {
            try
            {
                errore = false;
                Console.Write("Inserisci il nome dello studente: ");
                nome = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nome))
                {
                    throw new FormatException("Il nome non può essere vuoto.");
                }
            }
            catch (FormatException ex)
            {
                errore = true;
                Console.WriteLine("Errore di formato: " + ex.Message);
            }
        }

        errore = true;
        while (errore)
        {
            try
            {
                errore = false;
                Console.Write("Inserisci il cognome dello studente: ");
                cognome = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(cognome))
                {
                    throw new FormatException("Il cognome non può essere vuoto.");
                }
            }
            catch (FormatException ex)
            {
                errore = true;
                Console.WriteLine("Errore di formato: " + ex.Message);
            }
        }

        errore = true;
        while (errore)
        {
            try
            {
                errore = false;
                Console.Write("Inserisci il numero di discipline: ");
                nDiscipline = int.Parse(Console.ReadLine());
                if (nDiscipline < 0)
                {
                    throw new FormatException("Il numero di discipline non può essere negativo.");
                }
            }
            catch (FormatException ex)
            {
                errore = true;
                Console.WriteLine("Errore di formato: " + ex.Message);
            }
        }


        Studente studente = new Studente(nome, cognome, nDiscipline);


        for (int i = 0; i < nDiscipline; i++)
        {
            errore = true;
            while (errore)
            {
                try
                {
                    errore = false;
                    Console.WriteLine($"Inserisci i risultati per la disciplina {i + 1} (separati da spazi, es: 5 3 10 2, oppure lascia vuoto): ");
                    string input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        break; 
                    }

                    string[] risultati = input.Split(' ');

                    foreach (string risultato in risultati)
                    {
                        if (int.TryParse(risultato, out int risultatoInt))
                        {
                            studente.AggiungiRisultatoDisciplina(i, risultatoInt);
                        }
                        else
                        {
                            throw new FormatException($"Risultato non valido: {risultato}");
                        }
                    }
                }
                catch (FormatException ex)
                {
                    errore = true;
                    Console.WriteLine("Errore di formato: " + ex.Message);
                }
            }
        }

        for (int i = 0; i < nDiscipline; i++)
        {
            Console.WriteLine($"Miglior risultato disciplina {i + 1}: " + studente.MigliorRisultatoDisciplina(i));
        }

        Console.WriteLine("Miglior risultato assoluto: " + studente.MigliorRisultatoAssoluto());

        Console.WriteLine("Numero totale di risultati ottenuti: " + studente.NumeroTotaleRisultati());

        double[] risultatiMedi = studente.RisultatiMediPerDisciplina();
        for (int i = 0; i < risultatiMedi.Length; i++)
        {
            Console.WriteLine($"Risultato medio disciplina {i + 1}: {risultatiMedi[i]:F2}");
        }
    }
}
