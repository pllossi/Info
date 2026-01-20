using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boschi_VerificaInfo_11_12_2025
{
    public class Riordinatore : IComparer<Ordine>
    { 
        public int Compare(Ordine x, Ordine y)
        {
           if (x.Urgente && !y.Urgente) x.DataOrdine.CompareTo(y.DataOrdine);
           if (!x.Urgente && y.Urgente) x.DataOrdine.CompareTo(y.DataOrdine);
           return x.DataOrdine.CompareTo(y.DataOrdine);
        }
        
    }
}
