using System.Globalization;

namespace Atleta
{
    public class Studente
    {
        private string _nome;
        public string Nome
        {
            get
            {
                return _nome;
            }
            private set
            {
                if (value == " " || value == "")
                {
                    throw new System.Exception("Nome non valido");
                }
                _nome = value;
            }
        }
        private string _cognome;
        public string Cognome
        {
            get
            {
                return _cognome;
            }
            private set
            {
                if (value == " " || value == "")
                {
                    throw new System.Exception("Nome non valido");
                }
                _cognome = value;
            }
        }
        private int _nDiscipline;
        public int NDiscipline
        {
            get
            {
                return _nDiscipline;
            }
            private set
            {
                if (value < 0)
                {
                    throw new System.Exception("Numero discipline non valido");
                }
                _nDiscipline = value;
            }
        }
        private int[][] discipline;
        public Studente(string nome, string cognome, int nDiscipline)
        {
            _nome = nome;
            _cognome = cognome;
            _nDiscipline = nDiscipline;
            discipline = new int[nDiscipline][];
            for (int i = 0; i < nDiscipline; i++)
            {
                discipline[i] = new int[0];
            }
        }
        public void AggiungiRisultatoDisciplina(int disciplina, int risultato)
        {
            if (disciplina < 0 || disciplina >= _nDiscipline)
            {
                throw new System.Exception("Disciplina non valida");
            }
            if (risultato < 0)
            {
                throw new System.Exception("Risultato non valido");
            }
            int i = 0;
            while (true)
            {
                if ()
            }
        }

    }
}
