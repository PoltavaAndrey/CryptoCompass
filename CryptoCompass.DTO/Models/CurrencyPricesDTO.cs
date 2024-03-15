using System.Collections.Generic;

namespace CryptoCompass.DTO.Models
{
    public class CurrencyPricesDTO
    {
        public IEnumerable<CurrencyDetailDTO> data { get; set; }
        public long timestamp { get; set; }
    }
}
