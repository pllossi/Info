using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Carabinieri
{
    public class Caserma
    {
        public Caserma()
        {
            throw new System.NotImplementedException();
        }

        public string Nome
        {
            get => default;
            private set
            {
            }
        }

        public System.Collections.Generic.List<Carabiniere> Carabinieri
        {
            get => default;
            private set
            {
            }
        }

        public System.Collections.Generic.List<Multa> Multe
        {
            get => default;
            private set
            {
            }
        }

        public Posizione Posizione
        {
            get => default;
            private set
            {
            }
        }

        public System.Collections.Generic.List<Multa> MulteNonPagate()
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.List<Multa> MultePerVeicolo()
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.List<Multa> MultaPerCarabiniere()
        {
            throw new System.NotImplementedException();
        }

        public void PagaMulta()
        {
            throw new System.NotImplementedException();
        }

        public double TotaleMultePrescritte()
        {
            throw new System.NotImplementedException();
        }
    }
}