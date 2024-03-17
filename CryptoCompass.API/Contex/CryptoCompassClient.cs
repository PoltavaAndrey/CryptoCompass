using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using CryptoCompass.Data.Models;

namespace CryptoCompass.API.Contex
{
    public class CryptoCompassClient : IDisposable
    {
        private readonly HttpClient _client;
        private readonly string requestUri = "https://api.coincap.io/v2/assets",
            requestUriHistory1 = "https://api.coincap.io/v2/assets/",
            requestUriHistory2 = "/history?interval=d1";
        private HttpRequestMessage _requestMessage;

        private CurrencyPricesModel currencyPricesModel;

        public CryptoCompassClient()
        {
            _client = new HttpClient();
        }

        public async Task<CurrencyPricesModel> GetEnumerationOfDataAsync()
        {
            _requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
            var response = await _client.SendAsync(_requestMessage);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            currencyPricesModel = JsonSerializer.Deserialize<CurrencyPricesModel>(json);

            return currencyPricesModel;
        }

        public async Task<CurrencyHistoryPricesModel> GetDetailByIdAsync(string id)
        {
            _requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUriHistory1 + id + requestUriHistory2);
            var response = await _client.SendAsync(_requestMessage);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            CurrencyHistoryPricesModel currencyHistoryPricesModel = JsonSerializer.Deserialize<CurrencyHistoryPricesModel>(json);

            return currencyHistoryPricesModel;
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
