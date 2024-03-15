using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using CryptoCompass.Data.Models;
using System.Linq;

namespace CryptoCompass.API.Contex
{
    public class CryptoCompassClient : IDisposable
    {
        private readonly HttpClient _client;
        private readonly HttpRequestMessage _requestMessage;

        private CurrencyPricesModel _rootobject;

        public CryptoCompassClient()
        {
            _client = new HttpClient();
            _requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://api.coincap.io/v2/assets");
        }

        public async Task<CurrencyPricesModel> GetEnumerationOfDataAsync()
        {
            return await GetValueAsync(_requestMessage);
        }

        public async Task<CurrencyDetailModel> GetDetailByIdAsync(string id)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://api.coincap.io/v2/assets/" + id);
            var currentPriceModel = await GetValueAsync(_requestMessage);

            return currentPriceModel.CurrencyDetails.First();
        }

        private async Task<CurrencyPricesModel> GetValueAsync(HttpRequestMessage requestMessage)
        {
            try
            {
                var response = await _client.SendAsync(requestMessage);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                _rootobject = JsonSerializer.Deserialize<CurrencyPricesModel>(json);

                return _rootobject;
            }
            catch (HttpRequestException ex)
            {
                throw;
            }
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
