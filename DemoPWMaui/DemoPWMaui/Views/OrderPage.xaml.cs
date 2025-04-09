using CommunityToolkit.Mvvm.Input;

namespace DemoPWMaui.Views;

public partial class OrderPage : ContentPage
{
    private OrderViewModel _viewModel;

    public OrderPage(int? orderId = null)
    {
        // INITIALIZE COMPONENT è il metodo che inizializza la pagina come descritta nel file XAML
        // e la rende accessibile ai file scritti in codice C#.

        // BINDING CONTEXT è la proprietà nella quale viene definito quale viewmodel associare a questa view.

        InitializeComponent();
        _viewModel = new OrderViewModel(orderId);
        BindingContext = _viewModel;
    }

    // I GESTORI DEGLI EVENTI generati dai controlli (eg: button, entry) implementati nella view devono essere gestiti all'interno del file .xaml.cs. 
    // Questo perché le informazioni collegate ai controlli sono accessibili solo dentro alla stessa view (eg: i caratteri digitati dell'utente in una entry).
    public void OnNotesEntryCompleted(object sender, EventArgs e)
    {
        //ricorda: viene chiamato solo premendo invio
        var item = ((Entry)sender).Text;
        _viewModel.SetOrderNotes(item);
    }

    public void OnQuantityIndicated(object sender, EventArgs e)
    {
        //ricorda: viene chiamato solo premendo invio
        var text = ((Entry)sender).Text;
        var quantity = int.Parse(text);
        _viewModel.SetOrderQuantity(quantity);
    }

    // RELAY COMMAND crea un metodo che è possibile richiamare nel codice xaml.
    // Questo attributo è utilizzabile in tutti i file scritti in codice C# (quindi sia nel file .xaml.cs della view che nel viewmodel).
    // Il nome del metodo esposto viene generato secondo queste regole:
    //    - viene eliminato un eventuale "On" all'inizio;
    //    - viene eliminato un eventuale "Async" alla fine;
    //    - viene aggiunto "Command" alla fine del nome.
    // Esempi di trasformazione del nome: OnAppearing -> AppearingCommand, OpenPageAsync -> OpenPageCommand, NewOrder -> NewOrderCommand)

    // Lo stack di NAVIGAZIONE è accessibile solo nella view.
    // Di conseguenza, i comandi che lo modificano (eg: Push e Pop) devono essere gestiti nei file .xaml.cs.

    [RelayCommand]
    public async Task SaveOrder()
    {
        var hasError = _viewModel.SaveOrderInPreferences();
        if (hasError == false)
        {
            await Navigation.PopAsync();
        }
    }
}