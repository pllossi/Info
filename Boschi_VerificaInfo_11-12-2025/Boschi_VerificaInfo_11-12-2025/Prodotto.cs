using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boschi_VerificaInfo_11_12_2025
{
    public class Prodotto
    {
        private int _id;
        private string _nome;
        private float _prezzo;
        public int Id
        {
            private set
            {
                if( value < 0 )
                    throw new ArgumentOutOfRangeException( "L'id deve essere maggiore di 0" );
                _id = value;
            }
            get => _id;
        }
        public string Nome
        {
            private set
            {
                if(value==null||value.Length==0)
                    throw new ArgumentNullException( "Il nome non può essere nullo o vuoto" );
                _nome = value;
            }
            get => _nome;
        }
        public float Prezzo
        {
            private set
            {
                if (value < 0.0)
                    throw new ArgumentOutOfRangeException("Il prezzo non può essere negativo");
                _prezzo = value;
            }
            get => _prezzo;
        }
        public Prodotto(int id,string name,float price)
        {
            Id = id;
            Nome=name;
            Prezzo = price;
        }
    }
}
