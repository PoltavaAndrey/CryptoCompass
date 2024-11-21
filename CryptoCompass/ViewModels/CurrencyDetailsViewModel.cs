using CryptoCompass.Commands;
using CryptoCompass.DTO.Models;
using CryptoCompass.Services;
using CryptoCompass.Services.Services;
using CryptoCompass.Stores;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace CryptoCompass.ViewModels
{
    public class CurrencyDetailsViewModel : ViewModelBase
    {
        private CurrencyService _currencyService;
        public IEnumerable<CurrencyDetailDTO> СurrencyDetailDTOs;

        private readonly NavigationStore _navigationStore;

        public ICommand GetDetailsCommand { get; }

        public CurrencyDetailsViewModel(NavigationService navigationService)
        {
            GetDetailsCommand = new NavigateCommand(navigationService);
        }
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
    }
}
