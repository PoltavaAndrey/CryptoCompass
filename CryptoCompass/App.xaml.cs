using CryptoCompass.Stores;
using CryptoCompass.ViewModels;
using System.Windows;

namespace CryptoCompass
{
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;

        public App()
        {
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = CreateDetaisViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private CurrencyDetailsViewModel CreateCurrencyDetailsViewModel()
        {
            return new CurrencyDetailsViewModel(new Services.NavigationService(_navigationStore, CreateDetaisViewModel));
        }

        private CurrencyPopularityViewModel CreateDetaisViewModel()
        {
            return CurrencyPopularityViewModel.LoadViewModel(new Services.NavigationService(_navigationStore, CreateCurrencyDetailsViewModel));
        }
    }
}
