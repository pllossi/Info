namespace Show
{
    public class Biglietto
    {
        private double _prezzo;
        private int _posto;
        private bool _venduto;
        public double Prezzo { 
            get { return _prezzo; }
            private set {
                if(value > 0.0)
                    _prezzo = value;
                else
                    throw new System.Exception("Prezzo non valido");
            }
        }
        public int Posto { 
            get { return _posto; }
            private set {
                if(value > 0)
                    _posto = value;
                else
                    throw new System.Exception("Posto non valido");
            }
        }
        public bool Venduto { 
            get { return _venduto; }
            private set {
                _venduto = value;
            }
        }
        public Biglietto(double prezzo,int posto)
        {
            Posto = posto;
            Prezzo = prezzo;
            Venduto = false;
        }
        public void Vendita()
        {
            if(Venduto)
                throw new System.Exception("Biglietto già venduto");
            Venduto = true;
        }
        public void Reso() {
            if(!Venduto)
                throw new System.Exception("Biglietto non venduto");
            Venduto = false;
        }

    }
}
