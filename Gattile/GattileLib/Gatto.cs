using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GattileLib
{
    public class Gatto
    {
        private static HashSet<string> CodiciGenerati = new HashSet<string>();

        public Gatto(string nome = "", string razza = "", bool maschio = true, string? descrizione = null, DateTime? dataUscita = null, DateTime? dataNascita = null)
        {
            Nome = nome;
            Razza = razza;
            Maschio = maschio;
            Descrizione = descrizione;
            DataUscita = dataUscita;
            DataNascita = dataNascita;
            CodiceId = CreateCodiceId();
        }

        public string Nome
        {
            get => _nome;
            private set
            {
                if (value == "" || value == " ") { throw new ArgumentException(); }
                _nome = value;
            }
        }

        public DateTime DataArrivoGattile
        {
            get => _dataArrivoGattile;
            set
            {
                if(DataUscita.HasValue && value > DataUscita.Value)
                {
                    throw new ArgumentException("La data di arrivo non può essere successiva alla data di uscita.");
                }
                _dataArrivoGattile = value;
            }
        }

        private DateTime _dataArrivoGattile = DateTime.Now;

        public string Razza
        {
            get => _razza;
            private set
            {
                if (value == "" || value == " ") { throw new ArgumentException(); }
                _razza = value;
            }
        }

        public bool Maschio
        {
            get;
            private set;
        }

        private string _nome = string.Empty;

        private string _razza = string.Empty;

        private string? _descrizione = "";

        public string? Descrizione
        {
            get => _descrizione;
            set
            {
                if (value == "" || value == " ") { throw new ArgumentException(); }
                _descrizione = value;
            }
        }
        private DateTime? _dataUscita = null;
        public DateTime? DataUscita
        {
            get => _dataUscita;
            set
            {
                if (value.HasValue && value > DataArrivoGattile)
                {
                    throw new ArgumentException("La data di uscita non può essere precedente alla data di arrivo.");
                }
                _dataUscita = value;
            }
        }
        private DateTime? _dataNascita = null;
        public DateTime? DataNascita
        {
            get => _dataNascita;
            set => _dataNascita = value;
        }

        public string CodiceId = "";

        private string CreateCodiceId()
        {
            var rnd = new Random();
            string codice;
            do
            {
                int numero = rnd.Next(10000, 99999); // 5 cifre  
                char primaLetteraMese = DataArrivoGattile.ToString("MMM")[0];
                string anno = DataArrivoGattile.Year.ToString();
                string lettereRandom = new string(Enumerable.Range(0, 3)
                    .Select(_ => (char)rnd.Next(65, 91)).ToArray());
                codice = $"{numero}{primaLetteraMese}{anno}{lettereRandom}";
            } while (!CodiciGenerati.Add(codice)); // Assicura unicità  

            return codice;
        }
    }
}