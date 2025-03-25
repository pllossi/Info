namespace Talpa
{
    public class CampoDaGioco
    {
        private int[,] campo;
        private int _dimensione;
        private (int, int) posizioneTalpa;
        private int tentativi;

        public CampoDaGioco(int dimensione)
        {
            _dimensione = dimensione;
            campo = new int[dimensione, dimensione];
            tentativi = 0;
        }

        public void PosizionaTalpa(int x, int y)
        {
            if (x >= 0 && x < _dimensione && y >= 0 && y < _dimensione)
            {
                posizioneTalpa = (x, y);
                campo[x, y] = 1;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Le coordinate sono fuori dal campo da gioco.");
            }
        }

        public bool Tentativo(int x, int y)
        {
            tentativi++;
            if (x == posizioneTalpa.Item1 && y == posizioneTalpa.Item2)
            {
                return true;
            }
            return false;
        }

        public int GetTentativi()
        {
            return tentativi;
        }
    }
}
