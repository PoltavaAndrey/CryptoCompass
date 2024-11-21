using CryptoCompass.Commands;
using CryptoCompass.DTO.Models;
using CryptoCompass.Services;
using CryptoCompass.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CryptoCompass.ViewModels
{
    public class CurrencyPopularityViewModel : ViewModelBase
    {
        private ObservableCollection<CurrencyDetailDTO> _currencyDetailDTOs;
        public IEnumerable<CurrencyDetailDTO> CurrencyDetailDTOs => _currencyDetailDTOs;

        private readonly NavigationStore _navigationStore;

        public ICommand LoadPopularityCommand { get; }
        public ICommand GetDetailsCommand { get; }

        public CurrencyPopularityViewModel(NavigationService navigationService)
        {
            _currencyDetailDTOs = new ObservableCollection<CurrencyDetailDTO>();

            LoadPopularityCommand = new LoadCurrencyDetailsCommand(this);
            GetDetailsCommand = new NavigateCommand(navigationService);
        }

        public static CurrencyPopularityViewModel LoadViewModel(NavigationService navigationService)
        {
            CurrencyPopularityViewModel viewModel = new CurrencyPopularityViewModel(navigationService);

            viewModel.LoadPopularityCommand.Execute(null);

            return viewModel;
        }

        public void UpdatePopularity(IEnumerable<CurrencyDetailDTO> detailDTOs)
        {
            _currencyDetailDTOs.Clear();

            foreach (var detailDTO in detailDTOs)
            {
                _currencyDetailDTOs.Add(detailDTO);
            }
        }

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
    }
}
