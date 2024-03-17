using AutoMapper;
using CryptoCompass.Data.Models;
using CryptoCompass.DTO.Models;

namespace CryptoCompass.Services
{
    public class CryptoMappingProfile : Profile
    {
        public CryptoMappingProfile()
        {
            CreateMap<CurrencyDetailModel, CurrencyDetailDTO>();
            CreateMap<CurrencyPricesModel, CurrencyPricesDTO>();
            CreateMap<CurrencyHistoryPricesModel, CurrencyHistoryPricesDTO>();
            CreateMap<CurrencyHistoryModel, CurrencyHistoryDTO>();
        }
    }
}
