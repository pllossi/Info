using System.Numerics;

namespace GestioneNegozi
{
    public class Negozi
    {
        private string[] _nomi;
        private double?[,] _incassi;
        private int _nNegozi;
        public string[] Nomi
        {
            get { return _nomi; }
            private set
            {
                for (int i = 0; i < _nNegozi; i++)
                {
                    if (string.IsNullOrEmpty(value[0]))
                    {
                        throw new System.Exception("Nome negozio non valido");
                    }
                    _nomi[i] = value[i];
                }
            }
        }
        public double?[,] Incassi
        {
            get { return _incassi; }
            private set
            { 
            }
        }
        public Negozi(int nNegozi, string[]nomiNegozio)
        {
            if (nNegozi <= 0)
            {
                throw new System.Exception("Numero negozi non valido");
            }
            _nNegozi = nNegozi;
            _nomi = new string[nNegozi];
            _incassi = new double?[7,nNegozi];
            Nomi = nomiNegozio;
            for(int i = 0; i < 7; i++)
            {
                for (int j = 0; j < nNegozi; j++)
                {
                    _incassi[i, j] = null;
                }
            }
        }

        public void  InserisciIncasso(int negozio, int giorno, double? incasso)
        {
            if (negozio < 0 || negozio >= _nNegozi)
            {
                throw new System.Exception("Negozio non valido");
            }
            if (giorno < 0 || giorno >= 7)
            {
                throw new System.Exception("Giorno non valido");
            }
            if (incasso < 0)
            {
                throw new System.Exception("Incasso non valido");
            }
            _incassi[giorno, negozio] = incasso;
        }

        public void InserisciIncasso(string negozio, int giorno, double? incasso)
        {
            if (!_nomi.Contains(negozio))
            {
                throw new System.Exception("Negozio non valido");
            }
            if (giorno < 0 || giorno >= 7)
            {
                throw new System.Exception("Giorno non valido");
            }
            if (incasso < 0)
            {
                throw new System.Exception("Incasso non valido");
            }
            _incassi[giorno, Array.IndexOf(_nomi, negozio)] = incasso;
        }

        public void InserisciIncasso(int negozio, string giorno, double? incasso)
        {
            if (negozio < 0 || negozio >= _nNegozi)
            {
                throw new System.Exception("Negozio non valido");
            }
            if (giorno != "Lunedì" && giorno != "Martedì" && giorno != "Mercoledì" && giorno != "Giovedì" && giorno != "Venerdì" && giorno != "Sabato" && giorno != "Domenica")
            {
                throw new System.Exception("Giorno non valido");
            }
            if (incasso < 0)
            {
                throw new System.Exception("Incasso non valido");
            }
            _incassi[Array.IndexOf(new string[] { "Lunedì", "Martedì", "Mercoledì", "Giovedì", "Venerdì", "Sabato", "Domenica" }, giorno), negozio] = incasso;
        }
        public void InserisciIncasso(string negozio, string giorno, double? incasso)
        {
            if (!_nomi.Contains(negozio))
            {
                throw new System.Exception("Negozio non valido");
            }
            if (giorno != "Lunedì" && giorno != "Martedì" && giorno != "Mercoledì" && giorno != "Giovedì" && giorno != "Venerdì" && giorno != "Sabato" && giorno != "Domenica")
            {
                throw new System.Exception("Giorno non valido");
            }
            if (incasso < 0)
            {
                throw new System.Exception("Incasso non valido");
            }
            _incassi[Array.IndexOf(new string[] { "Lunedì", "Martedì", "Mercoledì", "Giovedì", "Venerdì", "Sabato", "Domenica" }, giorno),Array.IndexOf(_nomi,negozio)] = incasso;
        }

        public Double? IncassoTotale()
        {

            double? totale = 0;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < _nNegozi; j++)
                {
                    totale += _incassi[i, j];
                }
            }
            return totale;
        }

        public Double? IncassoTotalePerNegozio(string negozio)
        {
            if (!_nomi.Contains(negozio))
            {
                throw new System.Exception("Negozio non valido");
            }
            double? totale = 0;
            for (int i = 0; i < 7; i++)
            {
                totale += _incassi[i, Array.IndexOf(_nomi, negozio)];
            }
            return totale;
        }

        public Double? IncassoTotalePerNegozio(int negozio)
        {
            if (negozio<0||negozio>_nomi.Length)
            {
                throw new System.Exception("Negozio non valido");
            }
            double? totale = 0;
            for (int i = 0; i < 7; i++)
            {
                totale += _incassi[i, negozio];
            }
            return totale;
        }

        public Double? IncassoMedioPerNegozio(string negozio)
        {
            if (!_nomi.Contains(negozio))
            {
                throw new System.Exception("Negozio non valido");
            }
            double? totale = 0;
            int giorni = 0;
            for (int i = 0; i < 7; i++)
            {
                if (_incassi[i, Array.IndexOf(_nomi, negozio)] != null)
                {
                    totale += _incassi[i, Array.IndexOf(_nomi, negozio)];
                    giorni++;
                }
            }
            if (totale == 0) return null;
            return totale/giorni;
        }

        public Double? IncassoMedioPerNegozio(int negozio)
        {
            if (negozio < 0 || negozio > _nomi.Length)
            {
                throw new System.Exception("Negozio non valido");
            }
            double? totale = 0;
            int giorni = 0;
            for (int i = 0; i < 7; i++)
            {
                if (_incassi[i, negozio] != null)
                {
                    totale += _incassi[i, negozio];
                    giorni++;
                }
            }
            if (totale == 0) return null;
            return totale / giorni;
        }

        public string?[] GiornoDiChiusura(string negozio) {
            if (!_nomi.Contains(negozio))
            {
                throw new System.Exception("Negozio non valido");
            }
            string?[] giorni = new string?[7];
            for (int i = 0; i < 7; i++)
            {
                if (_incassi[i, Array.IndexOf(_nomi, negozio)] == null)
                {
                    giorni[i] = new string[] { "Lunedì", "Martedì", "Mercoledì", "Giovedì", "Venerdì", "Sabato", "Domenica" }[i];
                }
            }
            return giorni;
        }

        public string?[] GiornoDiChiusura(int negozio)
        {
            if (negozio < 0 || negozio > _nomi.Length)
            {
                throw new System.Exception("Negozio non valido");
            }
            string?[] giorni = new string?[7];
            for (int i = 0; i < 7; i++)
            {
                if (_incassi[i, negozio] == null)
                {
                    giorni[i] = new string[] { "Lunedì", "Martedì", "Mercoledì", "Giovedì", "Venerdì", "Sabato", "Domenica" }[i];
                }
            }
            return giorni;
        }

        public string[][] MaggiorIncassoPerGiorno()
        {
            string[][] negozi = new string[7][];
            for (int i = 0; i < 7; i++)
            {
                negozi[i] = new string[] { };
                double? max = 0;
                for (int j = 0; j < _nNegozi; j++)
                {
                    if (_incassi[i, j] > max)
                    {
                        max = _incassi[i, j];
                        negozi[i] = new string[] { _nomi[j] };
                    }
                    else if (_incassi[i, j] == max)
                    {
                        Array.Resize(ref negozi[i], negozi[i].Length + 1);
                        negozi[i][negozi[i].Length - 1] = _nomi[j];
                    }
                }
            }
            return negozi;
        }
    }
}
