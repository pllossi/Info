namespace Dice_and_Statistics
{
    public class Player
    {
        private string _name;
        public string Name
        {
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new System.ArgumentException("Name not valid", "Name");
                }
                _name = value;
            }
            get
            {
                return _name;
            }
        }
        public int[] Score { get; private set; }
        public int[] DiceFrequencies { get; private set; }

        public Player(string name, int times = 1)
        {
            Name = name;
            Score = new int[times];
            DiceFrequencies = new int[6]; // Inizializza DiceFrequencies
        }

        public void ThrowDice(int times)
        {
            DiceFrequencies = new int[6];
            if (times < 0)
            {
                throw new System.ArgumentException("Times not valid", "times");
            }
            for (int i = 0; i < times; i++)
            {
                Score[i] = new Random().Next(1, 7);
                DiceFrequencies[Score[i] - 1] += 1;
            }
        }

        public void ThrowDice()
        {
            ThrowDice(1);
        }

        public int TotalScore
        {
            get
            {
                int times6 = 0;
                int sum = 0;
                foreach (var item in Score)
                {
                    sum += item;
                    if (item == 6)
                    {
                        times6++;
                    }
                }
                return sum * times6;
            }
            private set { }
        }

        public int[] numberPositions(int number)
        {
            if (number < 1 || number > 6)
            {
                throw new System.ArgumentException("Number not valid", "number");
            }
            int[] positions = new int[Score.Length];
            int j = 0;
            for (int i = 0; i < Score.Length; i++)
            {
                if (Score[i] == number)
                {
                    positions[j] = i;
                    j++;
                }
            }
            return positions;
        }

        public bool isCheater()
        {
            foreach (var item in DiceFrequencies)
            {
                if (item > Score.Length / 2)
                {
                    return true;
                }
            }
            return false;
        }

        public int GetNumberFrequency(int number)
        {
            if (number < 1 || number > 6)
            {
                throw new System.ArgumentException("Number not valid", "number");
            }
            int percentage = DiceFrequencies[number - 1] * 100 / Score.Length;
            return percentage;
        }
    }
}
