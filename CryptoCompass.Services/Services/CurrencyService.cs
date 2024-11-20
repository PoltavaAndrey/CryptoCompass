using CryptoCompass.DTO.Models;
using CryptoCompass.API.Contex;
using CryptoCompass.Services.Interfaces;
using System.Threading.Tasks;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using CryptoCompass.Data.Models;

namespace CryptoCompass.Services.Services
{
    public class CurrencyService : ICurrencyService
    {
        public async Task<IEnumerable<CurrencyHistoryDTO>> GetCurrencyDetailsAsync(string currencyId)
        {
            CryptoCompassClient cryptoCompassClient = new CryptoCompassClient();
            CurrencyHistoryPricesModel currencyHistoryPricesModel = await cryptoCompassClient.GetDetailByIdAsync(currencyId);

            var config = new MapperConfiguration(cfg => cfg.AddProfile<CryptoMappingProfile>());
            var mapper = config.CreateMapper();
            CurrencyHistoryPricesDTO currencyHistoryPricesDTO = mapper.Map<CurrencyHistoryPricesDTO>(currencyHistoryPricesModel);
            IEnumerable<CurrencyHistoryDTO> currencyHistoryDTOs = currencyHistoryPricesDTO.data.Take(20);

            cryptoCompassClient.Dispose();
            return currencyHistoryDTOs;
        }

        public async Task<IEnumerable<CurrencyDetailDTO>> GetCurrencyPricesAsync()
        {
            CryptoCompassClient cryptoCompassClient = new CryptoCompassClient();
            var currencyPricesModel = await cryptoCompassClient.GetEnumerationOfDataAsync();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<CryptoMappingProfile>());
            var mapper = config.CreateMapper();
            CurrencyPricesDTO currencyPricesDTO = mapper.Map<CurrencyPricesDTO>(currencyPricesModel);
            IEnumerable<CurrencyDetailDTO> currencyDetailDTO = currencyPricesDTO.data.Take(10);

            cryptoCompassClient.Dispose();
            return currencyDetailDTO;
        }
    }
}
