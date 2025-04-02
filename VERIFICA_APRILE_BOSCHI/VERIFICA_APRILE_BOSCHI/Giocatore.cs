using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VERIFICA_APRILE_BOSCHI
{
    public class Giocatore
    {
        public int Tentativi 
        {
            get;
            private set;
        }

        public void TentativoInserito()
        {
            ++Tentativi;
        }
    }
}
