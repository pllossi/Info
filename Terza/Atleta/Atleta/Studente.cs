using System;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization.Formatters;

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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Nome non valido");
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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Cognome non valido");
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
                    throw new Exception("Numero discipline non valido");
                }
                _nDiscipline = value;
            }
        }

        private int[][] discipline;

        public Studente(string nome, string cognome, int nDiscipline)
        {
            Nome = nome;
            Cognome = cognome;
            NDiscipline = nDiscipline;
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
                throw new Exception("Disciplina non valida");
            }
            if (risultato < 0)
            {
                throw new Exception("Risultato non valido");
            }
            Array.Resize(ref discipline[disciplina], discipline[disciplina].Length + 1);
            discipline[disciplina][^1] = risultato;
        }

        public int MigliorRisultatoDisciplina(int disciplina)
        {
            if (disciplina < 0 || disciplina >= _nDiscipline)
            {
                throw new Exception("Disciplina non valida");
            }
            return discipline[disciplina].Length > 0 ? discipline[disciplina].Max() : 0;
        }

        public int MigliorRisultatoAssoluto()
        {
            int max=int.MinValue;
            for (int i = 0; i < _nDiscipline; i++)
            {
                int lunghezza = discipline[i].Length;
                for(int j = 0; j < lunghezza; j++)
                {
                    if (discipline[i][j] > max)
                    {
                        max = discipline[i][j];
                    }
                }
            }
            return max;
        }

        public int NumeroTotaleRisultati()
        {
            int ris= 0;
            for (int i = 0; i < _nDiscipline; i++)
            {
                ris += discipline[i].Length;
            }
            return ris;
        }

        public double[] RisultatiMediPerDisciplina()
        {
            double[] ris = new double[_nDiscipline];
            for (int i = 0; i < _nDiscipline; i++)
            {
                int lunghezza = discipline[i].Length;
                double somma = 0;
                for (int j = 0; j < lunghezza; j++)
                {
                    somma += discipline[i][j];
                }
                ris[i] = somma / lunghezza;
            }
            return ris;
        }
    }
}
