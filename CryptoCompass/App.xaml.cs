using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoCompass
{
    public partial class App : Application
    {
        public string CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencySymbol { get; set; }
        public string CurrencySupply { get; set; }
        public string CurrencyMaxSupply { get; set; }
        public string CurrencyMarketCapUsd { get; set; }
        public string CurrencyPriceUsd { get; set; }
    }
}
