using Dice_and_Statistics;
bool error = false;
int n = 0;
do
{
    try
    {
        n = int.Parse(Console.ReadLine());
    }
    catch (Exception)
    {
        error = true;
        Console.WriteLine("Errore: valore non intero,o troppo grande o errore sconosciuto all'umanità");
    }
}
while (error);
error = false;
Game[] games = new Game[n];
for (int i = 0; i < n; i++)
{
    do
    {
        try
        {
            Console.WriteLine("Game number " + (i + 1));
            error = false;
            Console.WriteLine("Insert the first player name");
            string name1 = Console.ReadLine();
            Console.WriteLine("Insert the second player name");
            string name2 = Console.ReadLine();
            Console.WriteLine("Insert the number time that you want to play");
            int l = int.Parse(Console.ReadLine());
            games[i] = new Game(name1, name2, l);
            games[i].Play(l);
            Console.WriteLine(games[i].Winner);
        }
        catch (Exception e)
        {
            error = true;
            Console.WriteLine(e.Message);
        }
    }
    while (error);
}
error = false;
do
{
    try
    {
        error = false;
        int res = 0;
        Console.WriteLine("Insert the number that you want to know the frequency");
        int number = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            res += games[i].totalFrequencies(number);
        }
        Console.WriteLine("The number " + number + " has been thrown " + res + " times");
    }
    catch (Exception e)
    {
        error = true;
        Console.WriteLine(e.Message);
    }
}
while (error);
