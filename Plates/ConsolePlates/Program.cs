using Plates;

Console.WriteLine("Insert the number of plates that you want to save");
int plates = int.Parse(Console.ReadLine());
FavoriteDish favoriteDish = new FavoriteDish(plates);
for (int i = 0; i < plates; i++)
{
    bool hasError = false;
    do
    {
        hasError = false;
        try
        {
            Console.WriteLine("Insert the name of the dish");
            string name = Console.ReadLine();
            Console.WriteLine("Insert the name of the resturant");
            string resturant = Console.ReadLine();
            Console.WriteLine("Insert the price of the dish");
            int price = int.Parse(Console.ReadLine());
            Console.WriteLine("Insert the type of the dish");
            Console.WriteLine("1) Appetizer");
            Console.WriteLine("2) MainCourse");
            Console.WriteLine("3) SecondCourse");
            Console.WriteLine("4) SideCourse");
            Console.WriteLine("5) Dessert");
            DishType type = (DishType)int.Parse(Console.ReadLine());
            favoriteDish.insertDish(name, resturant, price, type);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            hasError = true;
        }
    } while (hasError);
}
Console.WriteLine("The plates that are the less expensive for each type are:");
Dish[] lessExpensive = favoriteDish.lessExpensiveForType();
for (int i = 0; i < lessExpensive.Length; i++)
{
    Console.WriteLine(lessExpensive[i].DishName);
}
int numResturantNames = favoriteDish.resturantsMoreThan1World();
Console.WriteLine("The number of resturants that have more than one word in their name is: " + numResturantNames);
Dish longestName = favoriteDish.LongestName();
Console.WriteLine("The dish with the longest name is: " + longestName.DishName);
bool error = false;
Dish?[] dishes = null;
do
{
    error = false;
    try
    {
        Console.WriteLine("Insert the name of the resturant that you want to know the paltes that you like");
        string resturant = Console.ReadLine();
        dishes = favoriteDish.DishesResturant(resturant);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        error = true;
    }
} while (error);
Console.WriteLine("The dishes that you like from the resturant are:");
bool printed = false;
for (int i = 0; i < dishes.Length; i++)
{
    if (dishes[i] != null)
    {
        printed = true;
        Console.WriteLine(dishes[i].DishName);
    }
}
if (!printed)
{
    Console.WriteLine("You don't like any dish from that resturant");
}