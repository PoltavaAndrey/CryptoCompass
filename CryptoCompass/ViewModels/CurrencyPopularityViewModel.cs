using CryptoCompass.Commands;
using CryptoCompass.DTO.Models;
using CryptoCompass.Services.Services;
using CryptoCompass.Stores;
using System.Collections.Generic;
using System.Windows.Input;

namespace CryptoCompass.ViewModels
{
    public class CurrencyPopularityViewModel : ViewModelBase
    {
        private CurrencyService _currencyService;
        public IEnumerable<CurrencyDetailDTO> СurrencyDetailDTOs;

        private readonly NavigationStore _navigationStore;

        public ICommand GetDetailsCommand { get; }

        public CurrencyPopularityViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _currencyService = new CurrencyService();

            GetDetailsCommand = new NavigateCommand(_navigationStore);
        }

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
    }
}
