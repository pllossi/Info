namespace PascalStudents
{
    public class Students
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        private int[] votes;
        public bool isBiennial { get; private set; }
        public Students(string name, string surname, bool isBiennial)
        {
            Name = name;
            Surname = surname;
            if (isBiennial)
            {
                votes = new int[13];
            }
            else
            {
                votes = new int[10];
            }
            this.isBiennial = isBiennial;
        }

        public void SetVote(int vote)
        {
            int index = Int32.MaxValue;
            int i = 0;
            while (i < votes.Length && index == Int32.MaxValue)
            {
                if (votes[i] == 0)
                {
                    index = i;
                }
                i++;
            }
            if (index != Int32.MaxValue)
            {
                votes[index] = vote;
            }
            else
            {
                throw new Exception("Non ci sono più spazi per i voti");
            }
        }
        public double Average()
        {
            double sum = 0;
            int count = 0;
            for (int i = 0; i < votes.Length; i++)
            {
                if (votes[i] != 0)
                {
                    sum += votes[i];
                    count++;
                }
            }
            return sum / count;
        }
        public int ToSufficentGrades()
        {
            int count = 0;
            foreach (int vote in votes)
            {
                if (vote < 6)
                {
                    count++;
                }
            }
            return count;
        }

        public string Result()
        {
            if (votes.Length == 13)
            {
                if (ToSufficentGrades() > 5)
                {
                    return "failed";
                }
                if (ToSufficentGrades() == 0)
                {
                    return "passed";
                }
                return "suspended";
            }
            else
            {
                if (ToSufficentGrades() > 4)
                {
                    return "failed";
                }
                if (ToSufficentGrades() == 0)
                {
                    return "passed";
                }
                return "suspended";
            }
        }
        public int Vote(int index)
        {
            if(index >= 0 && index < votes.Length) throw new Exception("Voto non valido");
            return votes[index];
        }
    }
}
