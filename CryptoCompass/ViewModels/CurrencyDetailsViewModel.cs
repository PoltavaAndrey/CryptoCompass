using CryptoCompass.DTO.Models;
using CryptoCompass.Services.Services;
using CryptoCompass.Stores;
using System.Collections.Generic;

namespace CryptoCompass.ViewModels
{
    public class CurrencyDetailsViewModel : ViewModelBase
    {
        private CurrencyService _currencyService;
        public IEnumerable<CurrencyDetailDTO> СurrencyDetailDTOs;

        private readonly NavigationStore _navigationStore;

        public CurrencyDetailsViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _currencyService = new CurrencyService();

            // TODO: Add command
        }
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
    }
}
