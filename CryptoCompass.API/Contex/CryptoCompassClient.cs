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
            requestUri2 = "/history?interval=d1";
        private HttpRequestMessage _requestMessage;

        private CurrencyPricesModel currencyPricesModel;

        public CryptoCompassClient() => _client = new HttpClient();

        public async Task<string> GetDataFromURI(string requestUri)
        {
            _requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
            var response = await _client.SendAsync(_requestMessage);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            return json;
        }

        public async Task<CurrencyPricesModel> GetEnumerationOfDataAsync()
        {
            string json = await GetDataFromURI(requestUri);
            currencyPricesModel = JsonSerializer.Deserialize<CurrencyPricesModel>(json);

            return currencyPricesModel;
        }

        public async Task<CurrencyHistoryPricesModel> GetDetailByIdAsync(string id)
        {
            string json = await GetDataFromURI(requestUri + id + requestUri2);
            CurrencyHistoryPricesModel currencyHistoryPricesModel = JsonSerializer.Deserialize<CurrencyHistoryPricesModel>(json);

            return currencyHistoryPricesModel;
        }

        public void Dispose() => _client.Dispose();
    }
}
