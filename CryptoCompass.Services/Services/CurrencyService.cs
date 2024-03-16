using CryptoCompass.DTO.Models;
using CryptoCompass.API.Contex;
using CryptoCompass.Services.Interfaces;
using System;
using System.Threading.Tasks;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace CryptoCompass.Services.Services
{
    public class CurrencyService : ICurrencyService
    {
        public async Task<CurrencyDetailDTO> GetCurrencyDetailsAsync(string currencyId)
        {
            // 1 step: call API client and return base model
            // 2 step: map base model(result) to DTO object with automapper
            // 3 step: return DTO model
            CryptoCompassClient cryptoCompassClient = new CryptoCompassClient();
            var currencyDetailsAsync = await cryptoCompassClient.GetDetailByIdAsync(currencyId);

            var config = new MapperConfiguration(cfg => cfg.AddProfile<CryptoMappingProfile>());
            var mapper = config.CreateMapper();
            CurrencyDetailDTO currencyDetailDTO = mapper.Map<CurrencyDetailDTO>(currencyDetailsAsync);

            cryptoCompassClient.Dispose();
            return currencyDetailDTO;
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
