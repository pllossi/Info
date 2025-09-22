namespace Geometria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Punto p1 = new Punto(5, 7);
            //il costruttore di default non è richiamabile perchè ho definito un costruttore con 2 parametri
            Punto p = new Punto();

            //non sto chiamando il costruttore di default, ma il mio costruttore utilizzando i parametri di default che ho definito
            Punto p2 = new Punto();

            //Punto p3 = new Punto(5); ?? 5 è la x o la y???
        }
    }
}
