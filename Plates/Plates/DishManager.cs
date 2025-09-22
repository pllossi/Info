using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plates
{
    public class DishManager
    {
        private Dish[] dishes;

        public DishManager()
        {
            dishes = new Dish[0];  
        }

        public void AddDish(Dish dish)
        {
            foreach (Dish existingDish in dishes)
            {
                if (existingDish.Equals(dish)) throw new ArgumentException("Dish exists");

            }
            // nuovo array lungo di 1 in piú
            Dish[] newDishes = new Dish[dishes.Length + 1];

            // copio old dish in nuovo array di dish
            for (int i = 0; i < dishes.Length; i++)
            {
                newDishes[i] = dishes[i];
            }

            // inserisco il parametro dish nell'ultima posizione appena creata
            newDishes[dishes.Length] = dish;

            // array vecchio sovrascritto da array nuovo con il dish inserito.
            dishes = newDishes;

        }

        public Dish[] GetDishesInRestaurant(string restaurantName)
        {
            if (string.IsNullOrEmpty(restaurantName))
            {
                throw new ArgumentException("Restaurant name cannot be null or empty.", nameof(restaurantName));
            }
            // Conto quanti piatti corrispondono
            int count = 0;

            for (int i = 0; i < dishes.Length; i++)
            {
                if (dishes[i].Restaurant.Name == restaurantName)
                {
                    count++;
                }
            }

            // Se non ci sono piatti, restituisco un array vuoto
            if (count == 0)
            {
                return new Dish[0];
            }

            // Creo l'array di output
            Dish[] output = new Dish[count];
            int index = 0;

            // Copio i piatti corrispondenti nell'array di output
            for (int i = 0; i < dishes.Length; i++)
            {
                if (dishes[i].Restaurant.Name == restaurantName)
                {
                    output[index] = dishes[i];
                    index++;
                }
            }

            return output;
        }

        public Dish[] GetLowestPrice()
        {
            Dish?[] output = new Dish[5];


            for (int i = 0; i < dishes.Length; i++)
            {
                // Ottieni l'indice corrispondente alla tipologia del piatto
                int index = (int)dishes[i].Course;

                // Controlla se il prezzo corrente è il più basso trovato finora
                if (output[index] == null || dishes[i].Price < output[index]!.Price)
                {
                    output[index] = dishes[i];
                }
            }

            return output; // Restituisce l'array dei piatti con il prezzo più basso per ogni tipologia
        }
        public void SortDishes() => Array.Sort(dishes);
        public int CountRestaurantsWithMultiWordNames()
        {
            Dish[] CountRestaurantDishes = dishes;
            // Ordina l'array dei piatti in base al nome del ristorante
            Array.Sort(CountRestaurantDishes, (d1, d2) => d1.Restaurant.Name.CompareTo(d2.Restaurant.Name));

            int count = 0;
            string lastProcessedRestaurantName = string.Empty;

            for (int i = 0; i < CountRestaurantDishes.Length; i++)
            {
                string currentRestaurantName = CountRestaurantDishes[i].Restaurant.Name;

                // Se il ristorante corrente è diverso dall'ultimo processato
                if (currentRestaurantName != lastProcessedRestaurantName)
                {
                    lastProcessedRestaurantName = currentRestaurantName;

                    // Controlla se il nome del ristorante contiene più di una parola
                    if (currentRestaurantName.Contains(' '))
                    {
                        count++;
                    }
                }
            }
            return count;
        }


        public Dish? GetDishWithLongestName()
        {
            if (dishes.Length == 0)
            {
                return null; // Nessun piatto presente
            }

            Dish longestNameDish = dishes[0];

            for (int i = 1; i < dishes.Length; i++)
            {
                if (dishes[i].Name.Length > longestNameDish.Name.Length)
                {
                    longestNameDish = dishes[i];
                }
            }

            return longestNameDish;
        }

    }
}
