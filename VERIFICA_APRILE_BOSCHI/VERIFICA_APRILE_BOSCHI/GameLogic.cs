using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace VERIFICA_APRILE_BOSCHI
{
    public class GameLogic
    {
        private Giocatore _giocatore = new Giocatore();
        private GestioneCampoDiGioco _gestioneCampo;
        public GameLogic(int grandezzaCampo) {
            if(grandezzaCampo <= 0) throw new ArgumentOutOfRangeException(nameof(grandezzaCampo)+" deve esseee maggiore di 0");
            _gestioneCampo=new GestioneCampoDiGioco(grandezzaCampo);
        }
        public void PosizionaTesoro() {
            int coordX = 0;
            int coordY = 0;
            Random rand = new Random();
            coordX = rand.Next(0,_gestioneCampo.GetCampoDaGioco().GetLength(0));
            coordY = rand.Next(0, _gestioneCampo.GetCampoDaGioco().GetLength(1));
            _gestioneCampo.InserisciTesoro(coordX, coordY);
        }
        public bool Tentativo(int coordX,int coordY)
        {
            _giocatore.TentativoInserito();
            if (coordX < 0 || coordY < 0)
            {
                throw new ArgumentOutOfRangeException("Le coordinate devono essere maggiori di zero");
            }
            if (_gestioneCampo.GetCampoDaGioco()[coordX, coordY] == null|| _gestioneCampo.GetCampoDaGioco()[coordX, coordY] == false)
            {
                return false;
            } else
            {
                return true;
            }
        }

        public int NumeroTentativiFatti()
        {
            return _giocatore.Tentativi;
        }

    }
}
