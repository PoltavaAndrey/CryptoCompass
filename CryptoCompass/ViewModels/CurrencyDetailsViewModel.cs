using CryptoCompass.Commands;
using CryptoCompass.DTO.Models;
using CryptoCompass.Services;
using CryptoCompass.Stores;
using System.Windows.Input;

namespace CryptoCompass.ViewModels
{
    public class CurrencyDetailsViewModel : ViewModelBase
    {
        private readonly CurrencyDetailDTO _currencyDetailDTO;
        public CurrencyDetailDTO CurrencyDetailDTO => _currencyDetailDTO;

        private readonly NavigationStore _navigationStore;

        public ICommand GetDetailsCommand { get; }

        public CurrencyDetailsViewModel(CurrencyDetailDTO currencyDetailDTO, NavigationService navigationService)
        {
            GetDetailsCommand = new NavigateCommand(navigationService);
            _currencyDetailDTO = currencyDetailDTO;
        }
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
    }
}
