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
        public async Task<CurrencyDetailDTO> GetCurrencyDetailsAsync(string currencyId)
        {
            // TODO: call API client and return base model
            // 2 step: map base model(result) to DTO object with automapper
            // 3 step: return DTO model
            CryptoCompassClient cryptoCompassClient = new CryptoCompassClient();
            var currencyDetailsAsync = await cryptoCompassClient.GetDetailByIdAsync(currencyId);

            var config = new MapperConfiguration(cfg => cfg.AddProfile<CryptoMappingProfile>());
            var mapper = config.CreateMapper();
            CurrencyDetailDTO currencyDetailDTO = mapper.Map<CurrencyDetailDTO>(currencyDetailsAsync);

            throw new NotImplementedException();
        }

        public Task<CurrencyPricesDTO> GetCurrencyPricesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
