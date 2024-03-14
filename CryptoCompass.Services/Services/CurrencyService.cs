using CryptoCompass.DTO.Models;
using CryptoCompass.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace CryptoCompass.Services.Services
{
    public class CurrencyService : ICurrencyService
    {
        public Task<CurrencyDetailDTO> GetCurrencyDetaisAsync(string currencyId)
        {
            // TODO: call API client and return base model
            // 2 step: map base model(result) to DTO object with automapper
            // 3 step: return DTO model
            throw new NotImplementedException();
        }

        public Task<CurrencyPricesDTO> GetCurrencyPricesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
