using AutoMapper;
using CryptoCompass.API.Contex;
using CryptoCompass.Data.Models;
using CryptoCompass.DTO.Models;
using CryptoCompass.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCompass.Services.Services
{
    public class CurrencyService : ICurrencyService
    {
        public async Task<IEnumerable<CurrencyHistoryDTO>> GetCurrencyDetailsAsync(string currencyId)
        {
            return await FetchAndMapAsync(
                client => client.GetDetailByIdAsync(currencyId),
                model =>
                {
                    var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<CryptoMappingProfile>());
                    var mapper = mapperConfig.CreateMapper();
                    CurrencyHistoryPricesDTO dto = mapper.Map<CurrencyHistoryPricesDTO>(model);
                    return dto.data.Take(20);
                });
        }

        public async Task<IEnumerable<CurrencyDetailDTO>> GetCurrencyPricesAsync()
        {
            return await FetchAndMapAsync(
                client => client.GetEnumerationOfDataAsync(),
                model =>
                {
                    var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<CryptoMappingProfile>());
                    var mapper = mapperConfig.CreateMapper();
                    CurrencyPricesDTO dto = mapper.Map<CurrencyPricesDTO>(model);
                    return dto.data.Take(10);
                });
        }

        private async Task<TResult> FetchAndMapAsync<TModel, TResult>(Func<CryptoCompassClient, Task<TModel>> fetchDataFunc, Func<TModel, TResult> mapFunc)
        {
            using (var cryptoCompassClient = new CryptoCompassClient())
            {
                TModel model = await fetchDataFunc(cryptoCompassClient);

                var config = new MapperConfiguration(cfg => cfg.AddProfile<CryptoMappingProfile>());
                var mapper = config.CreateMapper();

                TResult result = mapFunc(model);
                return result;
            }
        }
    }
}
