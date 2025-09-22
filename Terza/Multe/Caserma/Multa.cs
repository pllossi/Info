using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Carabinieri
{
    public class Multa : IComparable<Multa>
    {
        public Multa()
        {
            throw new System.NotImplementedException();
        }

        public float? ImportoRiscosso
        {
            get => default;
            private set
            {
            }
        }

        public float Importo
        {
            get => default;
            private set
            {
            }
        }

        public System.DateTime DataEmissione
        {
            get => default;
            private set
            {
            }
        }

        public System.DateTime? DataNotifica
        {
            get => default;
            private set
            {
            }
        }

        public System.DateTime? DataPagamento
        {
            get => default;
            private set
            {
            }
        }

        public StatoEnum StatoMulta
        {
            get => default(StatoEnum);
            private set
            {
            }
        }

        public Intestatario Intestatario
        {
            get => default(Intestatario);
            private set
            {
            }
        }

        public Carabiniere Carabiniere
        {
            get => default(Carabiniere);
            private set
            {
            }
        }

        public string Descrizione
        {
            get => default;
            private set
            {
            }
        }

        public Veicolo Veicolo
        {
            get => default;
            private set
            {
            }
        }

        public void AnnullaMulta()
        {
            throw new System.NotImplementedException();
        }

        public void PagaMulta()
        {
            throw new System.NotImplementedException();
        }

        public void PrescriviMulta()
        {
            throw new System.NotImplementedException();
        }

        public int CompareTo(Multa other)
        {
            throw new System.NotImplementedException();
        }
    }
}