namespace Dice_and_Statistics
{
    public class Game
    {
        public Player Player1;
        public Player Player2;
        public Game(Player player1, Player player2, int times = 1) : this(player1.Name, player2.Name, times)
        { }
        public Game(string name1, string name2, int times)
        {
            if (times < 0)
                throw new ArgumentOutOfRangeException(nameof(times));
            Player1 = new Player(name1, times);
            Player2 = new Player(name2, times);
        }

        public void Play(int times)
        {
            Player1.ThrowDice(times);
            Player2.ThrowDice(times);
        }

        public string Winner
        {
            get
            {
                if (Player1.Score.Length != Player2.Score.Length)
                {
                    return "Errore: il numero di lanci dei due giocatori non è lo stesso";
                }
                if (Player1.isCheater() || Player2.isCheater())
                {
                    return "Errore: la partita è truccata";
                }
                if (Player1.TotalScore > Player2.TotalScore)
                {
                    return Player1.Name;
                }
                else if (Player1.TotalScore < Player2.TotalScore)
                {
                    return Player2.Name;
                }
                else
                {
                    return "Pareggio";
                }
            }
            private set { }
        }
        public int[] numberThrows(int number = 1)
        {
            if (number < 1 || number > 6)
            {
                throw new ArgumentOutOfRangeException(nameof(number));
            }
            int[] player1number = Player1.numberPositions(number);
            int[] player2number = Player2.numberPositions(number);
            int[] result = new int[player1number.Length + player2number.Length];
            for (int i = 0; i < player1number.Length; i++)
            {
                result[i] = player1number[i];
            }
            for (int i = 0; i < player2number.Length; i++)
            {
                result[i + player1number.Length] = player2number[i];
            }
            return result;
        }

        public int totalFrequencies(int number = 1)
        {
            if (number < 1 || number > 6)
            {
                throw new System.ArgumentException("Number not valid", "number");
            }
            int[] player1number = Player1.numberPositions(number);
            int[] player2number = Player2.numberPositions(number);
            int result = 0;
            for (int i = 0; i < player1number.Length; i++)
            {
                result += player1number[i];
            }
            for (int i = 0; i < player2number.Length; i++)
            {
                result += player2number[i];
            }
            return result;

        }
    }
}
