using System.Collections.Generic;

namespace CryptoCompass.DTO.Models
{
    public class CurrencyHistoryPricesDTO
    {
        public IEnumerable<CurrencyHistoryDTO> data { get; set; }
        public long timestamp { get; set; }
    }
}
