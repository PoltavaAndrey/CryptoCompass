using CryptoCompass.DTO.Models;
using CryptoCompass.Services.Services;
using CryptoCompass.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoCompass.Commands
{
    public class LoadCurrencyDetailsCommand : AsyncCommandBase
    {
        private CurrencyService _currencyService;
        public IEnumerable<CurrencyDetailDTO> _currencyDetailDTOs;
        private readonly CurrencyPopularityViewModel _viewModel;

        public LoadCurrencyDetailsCommand(CurrencyPopularityViewModel viewModel)
        {
            _currencyService = new CurrencyService();
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                _currencyDetailDTOs = await _currencyService.GetCurrencyPricesAsync();

                _viewModel.UpdatePopularity(_currencyDetailDTOs);
            }
            catch (Exception)
            {
                MessageBox.Show("Can't get prices!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
