namespace VERIFICA_GENNAIO_BOSCHI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //generalizzo tutto il problema
            Console.WriteLine("Benvenuto");
            Distributore distributore = null;
            int NProdotti=0;
            bool error=true;
            while (error) {
                error = false;
                try
                {
                    Console.WriteLine("Inserica il numero di prodotti che si vuole inserire nella macchinetta");
                    NProdotti=int.Parse(Console.ReadLine());
                    distributore = new Distributore(NProdotti);
                }
                catch (Exception ex)
                {
                    error = true;
                    Console.WriteLine(ex.ToString());
                }
            }
            error = true;
            while (error)
            {
                error = false;
                try
                {
                    for (int i = 0; i < NProdotti; i++)
                    {
                        Console.WriteLine("Inserisca il nome del prodotto numero " + (i+1) + " che si vuole inserire");
                        string nome = Console.ReadLine();
                        Console.WriteLine("Inserisca il prezzo per questo prodotto");
                        int prezzo=int.Parse(Console.ReadLine());
                        Console.WriteLine("Ora in base al tipo di prodotto che vuole innserire prema il numero in corrispondenza nella seguente tabella \n" + "1 = Merendina \n" + "2 = Snacks \n" + "3 = Bevanda");
                        int scelta=int.Parse(Console.ReadLine());
                        TipoProdotto tipoDelProdotto = 0;
                        bool erroreTipoProdotto = false;
                        while (erroreTipoProdotto)
                        {
                            erroreTipoProdotto = false;
                            switch (prezzo)
                            {
                                case 1:
                                    tipoDelProdotto = TipoProdotto.Merendina;
                                    break;
                                case 2:
                                    tipoDelProdotto = TipoProdotto.Snacks;
                                    break;
                                case 3:
                                    tipoDelProdotto = TipoProdotto.Bevanda;
                                    break;
                                default:
                                    Console.WriteLine("Questo tipo di prodotto non esiste, lo reinserisca");
                                    erroreTipoProdotto = true;
                                    break;
                            }
                        }
                        Console.WriteLine("Inserisca lo scompartimento dove si vuole inserire il Prodotto");
                        int.TryParse(Console.ReadLine(), out int scompartimento);
                        Prodotto prodotto = new Prodotto(nome, prezzo, tipoDelProdotto);
                        distributore.InserimentoProdotti(scompartimento, prodotto);
                    }
                }
                catch (Exception ex)
                {
                    error = true;
                    Console.WriteLine(ex.ToString());
                }
            }
            error = true;
            while (error)
            {
                error=false;
                try
                {
                    Console.WriteLine("Inserisca lo scompartimento dove troviamo il prodotto della quale si vuole sapere il prezzo");
                    int scompartimento=int.Parse(Console.ReadLine());
                    Console.WriteLine("Il prezzo del prodotto allo scompartimento " + scompartimento + " è: " + distributore.PrezzoProdottoSingolo(scompartimento));
                } catch (Exception ex)
                {
                    error = true;
                    Console.WriteLine(ex.ToString());
                }
            }
            Console.WriteLine("Il prezzo totale per i prodotti nella macchinetta è di: " + distributore.ValoreTotaleProdotti());
        }
    }
}
