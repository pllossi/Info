namespace Matrice
{
    public class MatriceClasse
    {
        private int[,] _matrice;
        private int _dimensione;

        public MatriceClasse(int dimensione)
        {
            _dimensione = dimensione;
            _matrice = new int[dimensione, dimensione];
        }

        public void RiempireMatrice(int[,] elementi)
        {
            if (elementi.GetLength(0) != _dimensione || elementi.GetLength(1) != _dimensione)
            {
                throw new ArgumentException("Le dimensioni della matrice non corrispondono.");
            }

            for (int i = 0; i < _dimensione; i++)
            {
                for (int j = 0; j < _dimensione; j++)
                {
                    _matrice[i, j] = elementi[i, j];
                }
            }
        }

        public bool VerificareDiagonalmenteDominante()
        {
            for (int i = 0; i < _dimensione; i++)
            {
                int somma = 0;
                for (int j = 0; j < _dimensione; j++)
                {
                    if (i != j)
                    {
                        somma += Math.Abs(_matrice[i, j]);
                    }
                }
                if (Math.Abs(_matrice[i, i]) <= somma)
                {
                    return false;
                }
            }
            return true;
        }

        public int CalcolareLunghezzaSequenzaMassima()
        {
            int maxLunghezza = 0;

            for (int i = 0; i < _dimensione; i++)
            {
                int lunghezzaCorrente = 1;
                for (int j = 1; j < _dimensione; j++)
                {
                    if (_matrice[i, j] == _matrice[i, j - 1])
                    {
                        lunghezzaCorrente++;
                    }
                    else
                    {
                        lunghezzaCorrente = 1;
                    }
                    if (lunghezzaCorrente > maxLunghezza)
                    {
                        maxLunghezza = lunghezzaCorrente;
                    }
                }
            }

            for (int j = 0; j < _dimensione; j++)
            {
                int lunghezzaCorrente = 1;
                for (int i = 1; i < _dimensione; i++)
                {
                    if (_matrice[i, j] == _matrice[i - 1, j])
                    {
                        lunghezzaCorrente++;
                    }
                    else
                    {
                        lunghezzaCorrente = 1;
                    }
                    if (lunghezzaCorrente > maxLunghezza)
                    {
                        maxLunghezza = lunghezzaCorrente;
                    }
                }
            }

            for (int k = 0; k < 2 * _dimensione - 1; k++)
            {
                int lunghezzaCorrente = 1;
                for (int i = Math.Max(0, k - _dimensione + 1); i < Math.Min(_dimensione, k + 1); i++)
                {
                    int j = k - i;
                    if (i > 0 && j > 0 && _matrice[i, j] == _matrice[i - 1, j - 1])
                    {
                        lunghezzaCorrente++;
                    }
                    else
                    {
                        lunghezzaCorrente = 1;
                    }
                    if (lunghezzaCorrente > maxLunghezza)
                    {
                        maxLunghezza = lunghezzaCorrente;
                    }
                }
            }

            for (int k = 0; k < 2 * _dimensione - 1; k++)
            {
                int lunghezzaCorrente = 1;
                for (int i = Math.Max(0, k - _dimensione + 1); i < Math.Min(_dimensione, k + 1); i++)
                {
                    int j = _dimensione - 1 - (k - i);
                    if (i > 0 && j < _dimensione - 1 && _matrice[i, j] == _matrice[i - 1, j + 1])
                    {
                        lunghezzaCorrente++;
                    }
                    else
                    {
                        lunghezzaCorrente = 1;
                    }
                    if (lunghezzaCorrente > maxLunghezza)
                    {
                        maxLunghezza = lunghezzaCorrente;
                    }
                }
            }

            return maxLunghezza;
        }
    }

}
