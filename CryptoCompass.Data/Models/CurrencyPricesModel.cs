using System.Collections.Generic;

namespace CryptoCompass.Data.Models
{
    public class CurrencyPricesModel
    {
        public IEnumerable<CurrencyDetailModel> data { get; set; }
        public long timestamp { get; set; }
    }
}
