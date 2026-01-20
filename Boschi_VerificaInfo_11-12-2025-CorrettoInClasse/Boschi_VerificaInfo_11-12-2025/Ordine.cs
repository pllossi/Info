using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Boschi_VerificaInfo_11_12_2025
{
    public class Ordine : IComparer<Ordine>
    {
        private int _id;
        private string _nomeCliente;
        private DateTime _dataOrdine;
        private string _dettagli;
        private Dictionary<Prodotto,int> _prodotti;
        private bool _urgente;
        public int Id
        {
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("L'id dell'ordine non può essere negativo");
                _id = value;
            }
            get => _id;
        }
        public string NomeCliente
        {
            private set
            {
                if (value is null || value.Length == 0)
                    throw new ArgumentException("Il nome del cliente non può essere nullo");
                _nomeCliente = value;
            }
            get => _nomeCliente;
        }
        public DateTime DataOrdine
        {
            get => _dataOrdine;
        }
        public string Dettagli
        {
            set => _dettagli = value;
            get => _dettagli;
        }
        public Dictionary<Prodotto, int> Prodotti
        {
            get => _prodotti;
        }
        public bool Urgente
        {
            get => _urgente;
        }
        public Ordine(int id,string nomeCliente,string dettagli,Dictionary<Prodotto, int> prodotti,bool urgente)
        {
            if (prodotti.Count == 0)
                throw new ArgumentException("I prodotti non posso essere 0 per fare un ordine");
            Id = id;
            _prodotti= prodotti;
            NomeCliente = nomeCliente;
            Dettagli = dettagli;
            _urgente = urgente;
            _dataOrdine= DateTime.Now;
        }

        public int Compare(Ordine? x, Ordine? y)
        {
            if (x == null && y == null) return 0;
            if (x.Urgente && y.Urgente)
            {
                if (x.DataOrdine > y.DataOrdine)
                    return -1;
                return 1;
            }
            else if (x.Urgente)
            {
                return 1;
            }
            else if (y.Urgente)
            {
                return -1;
            }
            else if (x.DataOrdine > y.DataOrdine)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
        public override string ToString()
        {
            return $"Id Ordine: {Id} \n Nome Cliente: {NomeCliente} \n Urgenza: {Urgente}";
        }
    }
}
