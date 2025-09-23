using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NoleggiLib
{
    public abstract class Veicolo
    {
        private double _prezzoPerGiorno;
        public double PrezzoPerGiorno
        {
            get
            {
                return _prezzoPerGiorno;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Il prezzo per giorno non può essere negativo.");
                _prezzoPerGiorno = value;
            }
        }
        private string _targa;
        public string Targa
        {
            get
            {
                return _targa;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La targa non può essere vuota.");
                _targa = value;
            }
        }

        private int _percentualeSconto;
        public int PercentualeSconto
        {
            get => _percentualeSconto;
            set
            {
                if(value < 0 || value >100) throw new ArgumentOutOfRangeException("percentuale sconto non accettabile");
                _percentualeSconto = value;
            }
        }

        private int _giorniPerSconto;
        public int GiorniPerSconto
        {
            get => _giorniPerSconto;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("giorni per sconto non accettabile");
                _giorniPerSconto = value;
            }
        }
        public abstract string Descrizione();

        public Veicolo(double prezzoPerGiorno, string targa, int percentualeSconto = 0,  int giorniPerSconto = 0)
        {
            PrezzoPerGiorno = prezzoPerGiorno;
            Targa = targa;
            PercentualeSconto = percentualeSconto;
            GiorniPerSconto = giorniPerSconto;
        }


    }
}
