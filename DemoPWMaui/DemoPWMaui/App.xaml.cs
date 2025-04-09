using DemoPWMaui.Views;

namespace DemoPWMaui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // impostata la schermata iniziale dell'app (la pagine alla base dello stack di navigazione)  
            MainPage = new NavigationPage(new ListPage());
        }
    }
}
