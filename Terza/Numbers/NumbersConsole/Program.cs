using NumberClasses;

namespace NumbersConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            string name;
            Console.WriteLine("Insert your name:");
            name = Console.ReadLine();
            Console.WriteLine($"Hello {name}! Welcome to the Numbers Console App!");
            int option=0;
            try
            {
                Console.WriteLine("If you want an even number press 1, if you want a random number press 2");
                option = int.Parse(Console.ReadLine());
                if(option != 1 && option != 2)
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid option, please try again");
            }
            if (option == 1)
            {
                game.StartGame(name, true);
            }
            else
            {
                game.StartGame(name, false);
            }
            bool win = false;
            while (!win)
            {
                Console.WriteLine("This is the tentative number: " + game.player.Tentatives);
                Console.WriteLine("Insert a number:");
                int guess = int.Parse(Console.ReadLine());
                win = game.Guess(guess);
                if (!win)
                {
                    Console.WriteLine("Try again!");
                    if(game.isLower)
                    {
                        Console.WriteLine("The number is lower");
                    }
                    else
                    {
                        Console.WriteLine("The number is higher");
                    }
                }
            }

        }
    }
}