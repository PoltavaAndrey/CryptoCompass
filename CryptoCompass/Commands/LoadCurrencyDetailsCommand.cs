using CryptoCompass.DTO.Models;
using CryptoCompass.Services.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoCompass.Commands
{
    public class LoadCurrencyDetailsCommand : AsyncCommandBase
    {
        private CurrencyService _currencyService;
        public IEnumerable<CurrencyDetailDTO> СurrencyDetailDTOs;

        public LoadCurrencyDetailsCommand()
        {
            _currencyService = new CurrencyService();
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                СurrencyDetailDTOs = await _currencyService.GetCurrencyPricesAsync();
            }
            catch (Exception)
            {
                MessageBox.Show("Can't get prices!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
