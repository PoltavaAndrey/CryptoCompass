using CryptoCompass.DTO.Models;
using CryptoCompass.Stores;
using CryptoCompass.ViewModels;
using System;
using System.Linq;
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
            var popularityViewModel = (CurrencyPopularityViewModel)_navigationStore.CurrentViewModel;
            CurrencyDetailDTO detailDTO;
            if (popularityViewModel.SelectedCurrencies != null && popularityViewModel.SelectedCurrencies.Count > 0)
            {
                detailDTO = (CurrencyDetailDTO)popularityViewModel.SelectedCurrencies[0];
            }
            else if (popularityViewModel.CurrencyDetailDTOs != null)
            {
                detailDTO = popularityViewModel.CurrencyDetailDTOs.FirstOrDefault();
                if (detailDTO == null)
                    throw new InvalidOperationException("No currencies available in the data source.");
            }
            else
            {
                throw new InvalidOperationException("No data available.");
            }

            return new CurrencyDetailsViewModel(detailDTO, new Services.NavigationService(_navigationStore, CreateDetaisViewModel));
        }

        private CurrencyPopularityViewModel CreateDetaisViewModel()
        {
            return CurrencyPopularityViewModel.LoadViewModel(new Services.NavigationService(_navigationStore, CreateCurrencyDetailsViewModel));
        }
    }
}
