using System.Collections.Generic;

namespace CryptoCompass.DTO.Models
{
    public class CurrencyPricesDTO
    {
        public IEnumerable<CurrencyDetailDTO> CurrencyDetails { get; set; }
        public long Timestamp { get; set; }
    }
}
