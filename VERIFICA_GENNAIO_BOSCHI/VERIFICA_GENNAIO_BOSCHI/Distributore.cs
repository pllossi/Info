namespace VERIFICA_GENNAIO_BOSCHI
{
    public class Distributore
    {
        private Prodotto?[] _scompartimenti;
        public Distributore(Prodotto?[] scompartimenti)
        {
            _scompartimenti = scompartimenti;
        }
        public Distributore(int numProdotti)
        {
            _scompartimenti= new Prodotto?[numProdotti];
        } 
        /// <summary>
        ///Ritorno il prezzo totale
        /// </summary>
        /// <returns></returns>
        public int ValoreTotaleProdotti()
        {
            int sum = 0;
            foreach (Prodotto? prodotto in _scompartimenti)
            {
                if (prodotto != null)
                {
                    sum += prodotto.PrezzoInCent;
                }
            }
            return sum;
        }
        /// <summary>
        /// Faccio in modo di inserire i prodotti
        /// </summary>
        /// <param name="scompartimento"></param>
        /// <param name="prodotto"></param>
        /// <exception cref="Exception"></exception>
        public void InserimentoProdotti(int scompartimento, Prodotto? prodotto)
        {
            if (scompartimento <= 0 || scompartimento > _scompartimenti.Length) throw new Exception("Questa scompartimento non esiste!");
            if (_scompartimenti[scompartimento-1] != null) throw new Exception($"Scompartimento già occupato da : {_scompartimenti[scompartimento-1].NomeProdotto}");
            _scompartimenti[scompartimento-1]= prodotto;
        }
        /// <summary>
        /// Ritorno un'oggetto in uno scompartimento
        /// </summary>
        /// <param name="scompartimento"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Prodotto? ProdottoNelloScompartimento(int scompartimento)
        {
            if (scompartimento <= 0 || scompartimento > _scompartimenti.Length) throw new Exception("Questa scompartimento non esiste!");
            return _scompartimenti[scompartimento-1];
        }
        /// <summary>
        /// Faccio in modo che in questo metodo ritorno il prezzo di un singolo oggetto
        /// </summary>
        /// <param name="scompartimento"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int PrezzoProdottoSingolo(int scompartimento) {
            if (scompartimento > 0 && scompartimento < _scompartimenti.Length) {
                if (_scompartimenti[scompartimento - 1] == null) throw new Exception("Prodotto non esistente");
                return _scompartimenti[scompartimento - 1].PrezzoInCent;
            }
            throw new Exception("Questa scompartimento non esiste!");
        }

    }
}
