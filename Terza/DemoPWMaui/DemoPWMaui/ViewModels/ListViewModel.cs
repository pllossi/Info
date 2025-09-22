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
    public partial class ListViewModel : ObservableObject
    {
        // OBSERVABLE COLLECTION è un tipo di elenco che permette di avere la view aggiornata automaticamente al cambiamento dei dati.
        // Ricorda che questo tipo di collection deve sempre essere dichiarata 'public'.

        public ObservableCollection<PizzaOrderModel> OrdersList { get; set; } = [];

        public ListViewModel()
        {
        }

        // RELAY COMMAND crea un metodo che è possibile richiamare nel codice xaml.
        // Questo attributo è utilizzabile in tutti i file scritti in codice C# (quindi sia nel file .xaml.cs della view che nel viewmodel).
        // Il nome del metodo esposto viene generato secondo queste regole:
        //    - viene eliminato un eventuale "On" all'inizio;
        //    - viene eliminato un eventuale "Async" alla fine;
        //    - viene aggiunto "Command" alla fine del nome.
        // Esempi di trasformazione del nome: OnAppearing -> AppearingCommand, OpenPageAsync -> OpenPageCommand, NewOrder -> NewOrderCommand)

        [RelayCommand]
        public void OnAppearing()
        {
            OrdersList.Clear();
            
            var orders = PreferencesUtilities.GetOrders();
            foreach (var order in orders)
            {
                OrdersList.Add(order);
            }
            

            ////imposta valori temporanei di PizzaOrders per facilitare il debugging nella fase iniziale
            ////(non è più necessario una volta che Orderpage sarà funzionante)   
           /*
            if (OrdersList.Count == 0)
            {
                OrdersList.Add(new PizzaOrderModel
                {
                    Base = "mozzarella",
                    Toppings = ["patatine", "wurstel"],
                    Notes = "poco pomodoro",
                    Quantity = 1,
                });
                OrdersList.Add(new PizzaOrderModel
                {
                    Base = "rossa",
                    Toppings = ["salsiccia"],
                    Quantity = 3,
                    Id = 2,
                });
                OrdersList.Add(new PizzaOrderModel
                {
                    Base = "bianca",
                    Toppings = ["funghi"],
                    Id = 3,
                });
            }
           */
        }

        [RelayCommand]
        public void DeleteOrder(int orderId)
        {
            
            PreferencesUtilities.DeleteOrder(orderId);

            OrdersList.Clear();

            var updatedOrders = PreferencesUtilities.GetOrders();
            foreach (var order in updatedOrders)
            {
                OrdersList.Add(order);
            }
            
        }
    }
}
