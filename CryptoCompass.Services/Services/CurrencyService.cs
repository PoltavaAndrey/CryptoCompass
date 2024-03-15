using CryptoCompass.DTO.Models;
using CryptoCompass.API.Contex;
using CryptoCompass.Services.Interfaces;
using System;
using System.Threading.Tasks;
using AutoMapper;

namespace CryptoCompass.Services.Services
{
    public class CurrencyService : ICurrencyService
    {
        private CryptoCompassClient cryptoCompassClient = new CryptoCompassClient();

        public async Task<CurrencyDetailDTO> GetCurrencyDetailsAsync(string currencyId)
        {
            // 1 step: call API client and return base model
            // 2 step: map base model(result) to DTO object with automapper
            // 3 step: return DTO model
            var currencyDetailsAsync = await cryptoCompassClient.GetDetailByIdAsync(currencyId);

            var config = new MapperConfiguration(cfg => cfg.AddProfile<CryptoMappingProfile>());
            var mapper = config.CreateMapper();
            CurrencyDetailDTO currencyDetailDTO = mapper.Map<CurrencyDetailDTO>(currencyDetailsAsync);

            return currencyDetailDTO;
        }

        public async Task<CurrencyPricesDTO> GetCurrencyPricesAsync()
        {
            var currencyPricesModel = await cryptoCompassClient.GetEnumerationOfDataAsync();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<CryptoMappingProfile>());
            var mapper = config.CreateMapper();
            CurrencyPricesDTO currencyPricesDTO = mapper.Map<CurrencyPricesDTO>(currencyPricesModel);

            return currencyPricesDTO;
        }
    }
}
