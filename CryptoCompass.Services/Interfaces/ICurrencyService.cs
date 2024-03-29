﻿using CryptoCompass.DTO.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoCompass.Services.Interfaces
{
    public interface ICurrencyService
    {
        Task<IEnumerable<CurrencyDetailDTO>> GetCurrencyPricesAsync();
        Task<IEnumerable<CurrencyHistoryDTO>> GetCurrencyDetailsAsync(string currencyId);
    }
}
