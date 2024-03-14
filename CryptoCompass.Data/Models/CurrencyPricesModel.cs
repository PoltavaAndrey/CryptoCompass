using System.Collections.Generic;

namespace CryptoCompass.Data.Models
{
    public class CurrencyPricesModel
    {
        public IEnumerable<CurrencyDetailModel> CurrencyDetails { get; set; }
        public long Timestamp { get; set; }
    }
}
