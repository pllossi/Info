using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace VERIFICA_APRILE_BOSCHI
{
    public class GestioneCampoDiGioco
    {
        private bool?[,] _campoDaGioco;
        public GestioneCampoDiGioco(int grandezza)
        {
            if (grandezza <= 0) { throw new ArgumentException(nameof(grandezza)+" deve essere maggiore di zero"); }
            _campoDaGioco=new bool?[grandezza,grandezza];
            for (int i = 0; i < _campoDaGioco.GetLength(0); i++)
            {
                for (int j = 0; j < _campoDaGioco.GetLength(1); j++)
                {
                    _campoDaGioco[i, j] = null;
                }
            }
        }
        public void InserisciTesoro(int coordX, int coordY)
        {
            if(coordX < 0 || coordY < 0)
            {
                throw new ArgumentOutOfRangeException("Le coordinate devono essere maggiori di zero");
            }
            _campoDaGioco[coordX, coordY] = true;
        }

        public bool?[,] GetCampoDaGioco()
        {
            return _campoDaGioco;
        }
    }
}
