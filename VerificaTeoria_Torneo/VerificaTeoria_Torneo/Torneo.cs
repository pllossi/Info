namespace VerificaTeoria_Torneo
{
    public class Torneo
    {
        private Giocatore[] giocatori;
        private Partita[][] risultatiGiocatori;
        public Torneo(Giocatore[] g, int maxPartite)
        {
            if (maxPartite < 0) throw new ArgumentOutOfRangeException("Il numero di partite deve essere maggiore di 0");
            giocatori = g;
            risultatiGiocatori = new Partita[giocatori.Length][];
            inizializzaRisultati(maxPartite);
        }

        private void inizializzaRisultati(int maxPartite)
        {
            for (int i = 0; i < giocatori.Length; i++)
            {
                risultatiGiocatori[i] = new Partita[maxPartite];
            }
        }

        public void AggiungiPartita(Partita partita)
        {
            if (partita.Giocatore1.Numero < 0 || partita.Giocatore1.Numero >= giocatori.Length) throw new ArgumentOutOfRangeException("Il giocatore deve essere uno dei 2 che gioca");
            if (partita.Giocatore2.Numero < 0 || partita.Giocatore2.Numero >= giocatori.Length) throw new ArgumentOutOfRangeException("Il giocatore deve essere uno dei 2 che gioca");
            if (partita.Numero < 0 || partita.Numero >= risultatiGiocatori[partita.Giocatore1.Numero].Length) throw new ArgumentOutOfRangeException("Il numero della partita è fuori range");
            risultatiGiocatori[partita.Giocatore1.Numero][partita.Numero] = partita;
            risultatiGiocatori[partita.Giocatore2.Numero][partita.Numero] = partita;

        }

        public int CalcolaPartiteGiocate(Giocatore giocatore)
        {
            if (giocatore.Numero < 0 || giocatore.Numero >= giocatori.Length) throw new ArgumentOutOfRangeException("Il giocatore deve essere uno dei 2 che gioca");

            int count = 0;
            for (int j = 0; j < risultatiGiocatori[giocatore.Numero].Length; j++)
            {
                if (risultatiGiocatori[giocatore.Numero][j] != null)
                {
                    count++;
                }
            }
            return count;

        }

        public int CalcolaVittorie(Giocatore giocatore)
        {
            if (giocatore.Numero < 0 || giocatore.Numero >= giocatori.Length) throw new Exception("Giocatore deve essere presente nel torneo");
            int vittorie = 0;
            for (int j = 0; j < risultatiGiocatori[giocatore.Numero].Length; j++)
            {
                if (risultatiGiocatori[giocatore.Numero][j] != null && risultatiGiocatori[giocatore.Numero][j].Vincitore == giocatore)
                {
                    vittorie++;
                }
            }
            return vittorie;

        }

        public int CalcolaSconfitte(Giocatore giocatore)
        {
            if (giocatore.Numero < 0 || giocatore.Numero >= giocatori.Length) throw new Exception("Giocatore deve essere presente nel torneo");


            int sconfitte = 0;

            for (int j = 0; j < risultatiGiocatori[giocatore.Numero].Length; j++)
            {
                if (risultatiGiocatori[giocatore.Numero][j] != null && risultatiGiocatori[giocatore.Numero][j].Vincitore != giocatore)
                {
                    sconfitte++;
                }
            }
            return sconfitte;
        }

        public int[,] MatriceRisultati(int numeroPartite = 4)
        {
            int[,] matrice = new int[giocatori.Length, numeroPartite];
            for (int i = 0; i < matrice.GetLength(0); i++)
            {
                for (int j = 0; j < matrice.GetLength(1); j++)
                {
                    if (risultatiGiocatori[i][j] != null)
                    {
                        if (risultatiGiocatori[i][j].Vincitore == null)
                        {
                            matrice[i, j] = 0;
                        }
                        else if (risultatiGiocatori[i][j].Vincitore == giocatori[i])
                        {
                            matrice[i, j] = 1;
                        }
                        else
                        {
                            matrice[i, j] = -1;
                        }
                    }
                }
            }
            return matrice;
        }
    }
}
