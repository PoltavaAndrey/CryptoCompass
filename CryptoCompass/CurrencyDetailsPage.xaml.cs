using CryptoCompass.DTO.Models;
using CryptoCompass.Services.Services;
using System.Collections.Generic;
using System.Windows.Controls;

namespace CryptoCompass
{
    public partial class CurrencyDetailsPage : Page
    {
        private CurrencyService currencyService;
        private IEnumerable<CurrencyHistoryDTO> currencyHistoryDTOs;

        public CurrencyDetailsPage()
        {
            InitializeComponent();

            currencyService = new CurrencyService();
        }

        private async void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            //string selected_dept = (App.Current as App).CurrencyId;
            //currencyHistoryDTOs = await currencyService.GetCurrencyDetailsAsync(selected_dept);

            //NameTextBlock.Text = "Name of currency: " + (App.Current as App).CurrencyName;
            //SymbolTextBlock.Text = "Symbol of currency: " + (App.Current as App).CurrencySymbol;
            //SupplyTextBlock.Text = "Supply of currency: " + (App.Current as App).CurrencySupply;
            //MaxSupplyTextBlock.Text = "Maximum supply of currency: " + (App.Current as App).CurrencyMaxSupply;
            //MarketCapUsdTextBlock.Text = "MarketCapUsd of currency: " + (App.Current as App).CurrencyMarketCapUsd;
            //PriceUsdTextBlock.Text = "Price usd of currency: " + (App.Current as App).CurrencyPriceUsd;

            CurrencyDetailsList.ItemsSource = currencyHistoryDTOs;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new System.Uri("/CurrencyPopularityPage.xaml", System.UriKind.Relative));
        }
    }
}