using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using DemoPWMaui.Models;

namespace DemoPWMaui.Infrastructure
{
    public static class PreferencesUtilities
    {
        private static readonly JsonSerializerOptions _defaultJsonSerializerOptions = new()
        {
            PropertyNameCaseInsensitive = true,
        };

        /// <summary>
        /// Accede alle Preferences per recuperare la lista delle pizze ordinate.
        /// </summary>
        /// <returns>La lista delle pizze ordinate.</returns>
        public static List<PizzaOrderModel> GetOrders()
        {
            var serializedSavedOrders = Preferences.Default.Get("orders", "");

            if (string.IsNullOrEmpty(serializedSavedOrders)) return [];

            var savedOrders = JsonSerializer.Deserialize<List<PizzaOrderModel>>(serializedSavedOrders, _defaultJsonSerializerOptions);
            return savedOrders ?? [];
        }

        /// <summary>
        /// Accede alle Preferences e recupera i dettagli dell'ordine indicato.
        /// </summary>
        /// <param name="id">Il numero identificatore dell'ordine.</param>
        /// <returns>I dettagli dell'ordine sotto forma di un'istanza di <see cref="PizzaOrderModel"/>.</returns>
        public static PizzaOrderModel GetOrder(int id)
        {
            var savedOrders = GetOrders();
            var order = savedOrders.Where(x => x.Id == id).First();

            return order;
        }

        /// <summary>
        /// Salva un nuovo ordine nelle Preferences oppure ne modifica uno già esistente. 
        /// Nel primo caso è necessario passare la base della pizza ed eventualmente la lista di ingredienti, le annotazioni e la quantità.
        /// Nel secondo caso invece è richiesto inserire l'id dell'ordine. 
        /// </summary>
        /// <param name="id">Il numero identificatore dell'ordine da modificare.</param>
        /// <param name="pizzaBase">Il condimento base della pizza del nuovo ordine.</param>
        /// <param name="toppings">La lista di ingredienti del nuovo ordine.</param>
        /// <param name="notes">Le annotazioni del nuovo ordine.</param>
        /// <param name="quantity">La quantità di pizze del nuovo ordine.</param>
        public static void SaveOrUpdateOrder(int? id, string pizzaBase, IEnumerable<string> toppings, string notes, int quantity)
        {
            var savedOrders = GetOrders();

            if (id.HasValue)
            {
                var orderToEdit = savedOrders.Where(x => x.Id == id.Value).First();

                orderToEdit.Base = pizzaBase;
                orderToEdit.Toppings = toppings.ToList();
                orderToEdit.Notes = notes;
                orderToEdit.Quantity = quantity;
            }
            else
            {
                savedOrders.Add(new PizzaOrderModel
                {
                    Id = savedOrders.Count + 1,
                    Base = pizzaBase,
                    Toppings = toppings.ToList(),
                    Notes = notes,
                    Quantity = quantity
                });
            }

            var serializedOrders = JsonSerializer.Serialize(savedOrders, _defaultJsonSerializerOptions);
            Preferences.Default.Set("orders", serializedOrders);
        }

        /// <summary>
        /// Rimuove l'ordine indicato dalla lista delle pizze ordinate salvata nelle Preferences.
        /// </summary>
        /// <param name="id">Il numero identificatore dell'ordine da rimuovere.</param>
        public static void DeleteOrder(int id)
        {
            var savedOrders = GetOrders();
            savedOrders.RemoveAt(id - 1);

            var count = 1;
            foreach (var order in savedOrders)
            {
                order.Id = count;
                count++;
            }

            var serializedOrders = JsonSerializer.Serialize(savedOrders, _defaultJsonSerializerOptions);
            Preferences.Default.Set("orders", serializedOrders);
        }
    }
}
