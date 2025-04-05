﻿namespace Talpa
{
    public class CampoDaGioco
    {
        private int[,] campo;
        private int _dimensione;
        private (int, int) posizioneTalpa;
        private int _tentativiMax;
        private int _tentativiRimanenti = 0;

        public CampoDaGioco(int dimensione, int tentativi)
        {
            if(dimensione <= 1) { throw new Exception("Il campo deve essere più grande di una sola casella");  }
            _dimensione = dimensione;
            campo = new int[dimensione, dimensione];
            _tentativiMax = tentativi;
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
            _tentativiMax--;
            _tentativiRimanenti++;
            if (x == posizioneTalpa.Item1 && y == posizioneTalpa.Item2)
            {
                return true;
            }
            return false;
        }

        public int GetTentativiRimanenti()
        {
            return _tentativiRimanenti;
        }

        public int GetTentativiMax()
        {
            return _tentativiMax;
        }
    }
}
