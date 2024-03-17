using System.Collections.Generic;

namespace CryptoCompass.Data.Models
{
    public class CurrencyHistoryPricesModel
    {
        public IEnumerable<CurrencyHistoryModel> data { get; set; }
        public long timestamp { get; set; }
    }
}
