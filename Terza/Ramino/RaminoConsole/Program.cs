using Ramino;


Torneo primoTorneo = new Torneo(7, 5);

Random random = new Random();
for (int partita = 1; partita <= primoTorneo.NumeroPartite; partita++)
    {
    for (int giocatore = 0; giocatore < 7; giocatore++)
    {
        int punteggio = random.Next(0, 101); // Genera un punteggio casuale tra 0 e 100
        primoTorneo.punteggioGiocatoreInPartita(giocatore, punteggio, partita);
    }
}

string vincitore = primoTorneo.Vincitore();
Console.WriteLine($"Il vincitore del torneo è: {vincitore}");

Console.Write("Inserisci il punteggio da cercare: ");
int P = int.Parse(Console.ReadLine());
//int P = 550;
//int? numeroPartita = primoTorneo._giocatori[0].RicercaPartitaPerPunteggio(P);


for (int giocatore = 0; giocatore < 7; giocatore++)
    {
    int? partita = primoTorneo._giocatori[giocatore].RicercaPartitaPerPunteggio(P);
    if (partita != null)
    {
        Console.WriteLine($"Il giocatore {primoTorneo._giocatori[giocatore].Nome} ha ottenuto esattamente {P} punti nella partita {partita + 1}");
    }
    else
    {
        Console.WriteLine($"Il giocatore {primoTorneo._giocatori[giocatore].Nome} non ha mai ottenuto esattamente {P} punti");
    }
}
