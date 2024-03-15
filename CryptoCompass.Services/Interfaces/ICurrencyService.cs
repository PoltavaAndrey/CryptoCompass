using CryptoCompass.DTO.Models;
using System.Threading.Tasks;

namespace CryptoCompass.Services.Interfaces
{
    public interface ICurrencyService
    {
        Task<CurrencyPricesDTO> GetCurrencyPricesAsync();
        Task<CurrencyDetailDTO> GetCurrencyDetailsAsync(string currencyId);
    }
}
