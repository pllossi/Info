using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DemoPWMaui.Infrastructure;
using DemoPWMaui.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPWMaui
{
    public partial class OrderViewModel : ObservableObject
    {
        public int Quantity { get; set; } = 1;

        public string Notes { get; set; } = string.Empty;

        // OBSERVABLE COLLECTION è un tipo di elenco che permette di avere la view aggiornata automaticamente al cambiamento dei dati.
        // Ricorda che questo tipo di collection deve sempre essere dichiarata 'public'.

        public ObservableCollection<ItemModel> AvailableBases { get; set; } = [];

        public ObservableCollection<ItemModel> AvailableToppings { get; set; } = [];

        // L'attributo OBSERVABLE PROPERTY serve per aggiornare automaticamente la view al cambiamento del valore del campo. 
        // Al suo utlizzo, viene creata una proprietà dello stesso tipo con il nome così generato:
        //    - viene rimosso un eventuale '_' iniziale;
        //    - la prima lettera diventa maiuscola.
        // Inoltre, la proprietà sarà dichiarata come 'public'. Per evitare errori di funzionamento, dichiarare 'private' il campo al quale è associato l'attributo.
        // La nuova proprietà sarà sempre quella da referenziare in tutto il codice (sia in xaml che in c#, compreso il resto del file in cui è stata dichiarata).
        // Per esempio:
        //    - dichiaro il campo _myString = "Hello" come ObservableProperty -> viene creata la proprietà MyString = "Hello";
        //    - per referenziarla, utilizzo sempre il nome 'MyString'.

        [ObservableProperty]
        private string _pageTitle = "Nuovo ordine";

        [ObservableProperty]
        private bool _hasError = false;

        [ObservableProperty]
        private string? _error = null;

        private int? _currentOrderId = null;

        public OrderViewModel(int? orderId = null)
        {
            AvailableToppings =
            [
                new ItemModel() { Value = "salsiccia" },
                new ItemModel() { Value = "funghi" },
                new ItemModel() { Value = "wurstel" },
                new ItemModel() { Value = "patatine" },
                new ItemModel() { Value = "verdure" },
                new ItemModel() { Value = "prosciutto" }
            ];

            AvailableBases =
            [
                new ItemModel() { Value = "rossa" },
                new ItemModel() { Value = "bianca" },
                new ItemModel() { Value = "margherita" },
            ];

            if (orderId.HasValue)
            {
                _currentOrderId = orderId;
                PageTitle = $"Modifica ordine n.{orderId}";

                var data = PreferencesUtilities.GetOrder(orderId.Value);
                Notes = data.Notes;
                Quantity = data.Quantity;

                foreach (var topping in AvailableToppings)
                {
                    if (data.Toppings.Contains(topping.Value))
                    {
                        topping.IsSelected = true;
                    }
                }

                foreach (var pizzaBase in AvailableBases)
                {
                    pizzaBase.IsSelected = pizzaBase.Value == data.Base;
                }

            }
        }

        public void SetOrderNotes(string value)
        {
            Notes = value;
        }

        public void SetOrderQuantity(int value)
        {
            Quantity = value;
        }

        public bool SaveOrderInPreferences()
        {
            if (AvailableBases.Where(x => x.IsSelected).Any() == false)
            {
                HasError = true;
                Error = "Selezionare la base della pizza";
                return true;
            }

            HasError = false;
            var pizzaBase = AvailableBases.Where(x => x.IsSelected).First().Value;
            var toppings = AvailableToppings.Where(x => x.IsSelected).Select(x => x.Value).ToList();

            PreferencesUtilities.SaveOrUpdateOrder(_currentOrderId, pizzaBase, toppings, Notes, Quantity);
            return false;
        }
    }

}
