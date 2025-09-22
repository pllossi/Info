using Plates;

DishManager dishManager = new DishManager();

bool exit = false;

static string PromptForNonEmptyInput(string message)
{
    string? input = null;
    while (string.IsNullOrWhiteSpace(input) || string.IsNullOrEmpty(input))
    {
        Console.WriteLine(message);
        input = Console.ReadLine()?.Trim();
        if (string.IsNullOrWhiteSpace(input) || string.IsNullOrEmpty(input))
            Console.WriteLine("Input cannot be empty. Please try again.");
    }
    return input;
}

while (!exit) //tutto dentro un while in modo tale che l'utente possa fare piú azioni fino a quando non vuole uscire volontariamente dal programma.
{
    Console.Clear();
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("1 = Add a dish");
    Console.WriteLine("2 = View dishes by restaurant");
    Console.WriteLine("3 = View the dish with the longest name");
    Console.WriteLine("4 = Count restaurants with multi-word names");
    Console.WriteLine("5 = View all dishes");
    Console.WriteLine("6 = Order dishes by type of course");
    Console.WriteLine("7 = Exit");
    Console.Write("Choose an option (1-7): "); //printo a schermo le opzioni

    string choice = Console.ReadLine()?.Trim() ?? ""; //leggo le opzioni

    try //try-catch in modo tale da non mandare il programma in crash nel caso di qualsiasi tipo di input errato.
    {
        switch (choice)
        {
            case "1":
                // aggiungi un piatto
                string name = PromptForNonEmptyInput("Enter the dish name:");
                string restaurantName = PromptForNonEmptyInput("Enter the restaurant name:");

                double price = 0; //anche qui inizializzo se no visual studio da errore senza nessun motivo.
                bool validPrice = false;
                while (!validPrice)
                {
                    Console.WriteLine("Enter the dish price:");
                    string input = Console.ReadLine()?.Trim() ?? "";
                    double.TryParse(input.Replace(',', '.'), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out price);
                    //un paio di funzioni di sistema per far convertire la stringa in double correttamente.
                    if (price <= 0)
                    {
                        Console.WriteLine("Invalid price.Please enter a positive number.");
                    }
                    else
                    {
                        validPrice = true;
                    }
                }

                //selezione del tipo di portata
                Dish.COURSE courseType = Dish.COURSE.Appetizer; // Inizializzo il valore ad Appetizer se no visual studio da errore.
                bool choose = false;
                while (!choose)
                {
                    Console.WriteLine("Select the dish course by entering the corresponding number:");
                    Console.WriteLine("0 = Appetizer");
                    Console.WriteLine("1 = Side");
                    Console.WriteLine("2 = First");
                    Console.WriteLine("3 = Second");
                    Console.WriteLine("4 = Dessert");
                    Console.Write("Enter your choice (0-4): ");

                    string input = Console.ReadLine()?.Trim() ?? "";
                    //prima parse, poi controllo se il valore parsato nella variabile finale sia uno di quelli della classe enum con isDefined.
                    if (Enum.TryParse(input.Replace(",", "."), true, out courseType) && Enum.IsDefined(typeof(Dish.COURSE), courseType))
                    {
                        choose = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid value. Please try again.");
                        choose = false;
                    }
                }
                // Creo e aggiungo il piatto
                Restaurant restaurant = new Restaurant(restaurantName);
                Dish dish = new Dish(name, courseType/* da errore per questo coso qua se sopra non lo inizializzo con un valore di base*/, price, restaurant);
                dishManager.AddDish(dish);
                Console.WriteLine("Dish added successfully!");
                break;

            case "2":
                // Visualizza piatti per risorante
                Console.WriteLine("Enter the restaurant name to view its dishes:");
                string restaurantToSearch = Console.ReadLine()?.Trim() ?? "";
                Dish[] dishesByRestaurant = dishManager.GetDishesInRestaurant(restaurantToSearch);
                if (dishesByRestaurant.Length == 0)
                {
                    Console.WriteLine("No dishes found for this restaurant.");
                }
                else
                {
                    Console.WriteLine($"Dishes in {restaurantToSearch}:");
                    foreach (Dish dishByRestaurant in dishesByRestaurant)
                    {
                        Console.WriteLine($"- {dishByRestaurant.Name} (Price: {dishByRestaurant.Price})");
                    }
                }
                break;

            case "3":
                // Piatto con nome piú lungo
                Dish? longestDish = dishManager.GetDishWithLongestName();
                if (longestDish == null)
                {
                    Console.WriteLine("No dishes found.");
                }
                else
                {
                    Console.WriteLine($"The dish with the longest name is: {longestDish!.Name}");
                }
                break;

            case "4":
                // Conta risoranti con un nome composto da piú parole
                int? multiWordRestaurants = dishManager.CountRestaurantsWithMultiWordNames();
                Console.WriteLine($"There are {multiWordRestaurants} restaurants with names containing more than one word.");
                break;

            case "5":
                // Visualizza tutti i piatti
                //dishManager.PrintAllDishes();
                break;

            //Ordina l'array in base al tipo di piatto
            case "6":
                dishManager.SortDishes();
                Console.WriteLine("Dishes are now sorted by type, if of the same type by name, and by the price if the name is the same");
                break;

            case "7":
                // Esce dal while
                exit = true;
                Console.WriteLine("Goodbye!");
                break;

            default:
                // Se l'utente non seleziona un numero compreso tra 1 e 7 finirá in questo caso printando il messaggio.
                Console.WriteLine("Invalid option, please try again.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}. Please try again.");
    }

    if (!exit)
    {
        //se l'utente non é uscito dal ciclo chiedo una conferma prima di continuare reiniziando il tutto.
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
