using Atleta;
using System;

class Program
{
    static void Main(string[] args)
    {
        // Creazione di un nuovo studente
        Studente studente = new Studente("Gianni", "Verdi", 3);

        // Aggiunta dei risultati per le discipline
        studente.AggiungiRisultatoDisciplina(0, 5);
        studente.AggiungiRisultatoDisciplina(0, 3);
        studente.AggiungiRisultatoDisciplina(0, 10);
        studente.AggiungiRisultatoDisciplina(0, 2);

        studente.AggiungiRisultatoDisciplina(2, 13);
        studente.AggiungiRisultatoDisciplina(2, 10);
        studente.AggiungiRisultatoDisciplina(2, 20);

        // Calcolo del miglior risultato per ogni disciplina
        Console.WriteLine("Miglior risultato disciplina 1: " + studente.MigliorRisultatoDisciplina(0));
        Console.WriteLine("Miglior risultato disciplina 2: " + studente.MigliorRisultatoDisciplina(1));
        Console.WriteLine("Miglior risultato disciplina 3: " + studente.MigliorRisultatoDisciplina(2));

        // Calcolo del miglior risultato assoluto
        Console.WriteLine("Miglior risultato assoluto: " + studente.MigliorRisultatoAssoluto());

        // Calcolo del numero totale di risultati ottenuti
        Console.WriteLine("Numero totale di risultati ottenuti: " + studente.NumeroTotaleRisultati());

        // Calcolo dei risultati medi per disciplina
        double[] risultatiMedi = studente.RisultatiMediPerDisciplina();
        for (int i = 0; i < risultatiMedi.Length; i++)
        {
            Console.WriteLine($"Risultato medio disciplina {i + 1}: {risultatiMedi[i]:F2}");
        }

        studente.AggiungiRisultatoDisciplina(0, -5);

    }
}
