namespace VerificaTeoria_Torneo
{
    public class Torneo
    {
        private Giocatore[] giocatori;
        private Partita[][] risultatiGiocatori;
        private int _maxPartite;

        public Torneo(Giocatore[] g, int maxPartite)
        {
            giocatori = g;
            inizializzaRisultati(maxPartite);
            _maxPartite = maxPartite;
        }

        private void inizializzaRisultati(int maxPartite)
        {
            risultatiGiocatori = new Partita[giocatori.Length][];
            for (int i = 0; i < giocatori.Length; i++)
            {
                risultatiGiocatori[i] = new Partita[maxPartite];
            }
        }

        public void AggiungiPartita(Partita partita)
        {
            for (int i = 0; i < giocatori.Length; i++)
            {
                if (giocatori[i].Numero == partita.Giocatore1.Numero || giocatori[i].Numero == partita.Giocatore2.Numero)
                {
                    for (int j = 0; j < risultatiGiocatori[i].Length; j++)
                    {
                        if (risultatiGiocatori[i][j] == null)
                        {
                            risultatiGiocatori[i][j] = partita;
                            break;
                        }
                    }
                }
            }
        }

        public int CalcolaPartiteGiocate(Giocatore giocatore)
        {
            for (int i = 0; i < giocatori.Length; i++)
            {
                if (giocatori[i].Numero == giocatore.Numero)
                {
                    int count = 0;
                    for (int j = 0; j < risultatiGiocatori[i].Length; j++)
                    {
                        if (risultatiGiocatori[i][j] != null)
                        {
                            count++;
                        }
                    }
                    return count;
                }
            }
            throw new Exception("Giocatore non presente nel torneo");
        }

        public int CalcolaVittorie(Giocatore giocatore)
        {
            int vittorie = 0;
            for (int i = 0; i < giocatori.Length; i++)
            {
                if (giocatori[i].Numero == giocatore.Numero)
                {
                    for (int j = 0; j < risultatiGiocatori[i].Length; j++)
                    {
                        if (risultatiGiocatori[i][j] != null && risultatiGiocatori[i][j].Vincitore?.Numero == giocatore.Numero)
                        {
                            vittorie++;
                        }
                    }
                    return vittorie;
                }
            }
            throw new Exception("Giocatore non presente nel torneo");
        }

        public int CalcolaSconfitte(Giocatore giocatore)
        {
            int sconfitte = 0;
            for (int i = 0; i < giocatori.Length; i++)
            {
                if (giocatori[i].Numero == giocatore.Numero)
                {
                    for (int j = 0; j < risultatiGiocatori[i].Length; j++)
                    {
                        if (risultatiGiocatori[i][j] != null && risultatiGiocatori[i][j].Vincitore != null && risultatiGiocatori[i][j].Vincitore.Numero != giocatore.Numero)
                        {
                            sconfitte++;
                        }
                    }
                    return sconfitte;
                }
            }
            throw new Exception("Giocatore non presente nel torneo");
        }

        public int[,] MatriceRisultati()
        {
            int[,] matrice = new int[giocatori.Length, _maxPartite];
            for (int i = 0; i < giocatori.Length; i++)
            {
                for (int j = 0; j < CalcolaPartiteGiocate(giocatori[i]); j++)
                {
                    if (risultatiGiocatori[i][j] != null)
                    {
                        if (risultatiGiocatori[i][j].Vincitore == null)
                        {
                            matrice[i, j] = 0;
                        }
                        else if (risultatiGiocatori[i][j].Vincitore.Numero == giocatori[i].Numero)
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
