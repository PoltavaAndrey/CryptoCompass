using CryptoCompass.DTO.Models;
using CryptoCompass.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CryptoCompass
{
    public partial class CurrencyPopularityPage : Page
    {
        private CurrencyService currencyService;
        private IEnumerable<CurrencyDetailDTO> currencyDetailDTOs;

        public CurrencyPopularityPage()
        {
            InitializeComponent();

            currencyService = new CurrencyService();
            DataContext = currencyDetailDTOs;
        }
            
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            currencyDetailDTOs = await currencyService.GetCurrencyPricesAsync();
            DataContext = currencyDetailDTOs;
        }

        private void ListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (CurrencyPopularityList.SelectedItems.Count == 0)
                CurrencyPopularityList.SelectedIndex = 0;

            CurrencyDetailDTO currencyDetailDTO = currencyDetailDTOs.ElementAt(CurrencyPopularityList.SelectedIndex);
            (App.Current as App).CurrencyId = currencyDetailDTO.id;
            (App.Current as App).CurrencyName = currencyDetailDTO.name;
            (App.Current as App).CurrencySymbol = currencyDetailDTO.symbol;
            (App.Current as App).CurrencySupply = currencyDetailDTO.supply;
            (App.Current as App).CurrencyMaxSupply = currencyDetailDTO.maxSupply;
            (App.Current as App).CurrencyMarketCapUsd = currencyDetailDTO.marketCapUsd;
            (App.Current as App).CurrencyPriceUsd = currencyDetailDTO.priceUsd;
            NavigationService.Navigate(new Uri("/CurrencyDetailsPage.xaml", UriKind.Relative));
        }

        private void FindByName_LostFocus(object sender, RoutedEventArgs e)
        {
            string nameOfElement = FindByNameTextBox.Text;
            try
            {
                var resultElement = currencyDetailDTOs.FirstOrDefault(element => element.name == nameOfElement);
                CurrencyPopularityList.SelectedIndex = int.Parse(resultElement.rank) - 1;
            }
            catch { }
        }

        private void FindBySymbol_LostFocus(object sender, RoutedEventArgs e)
        {
            string symbolOfElement = FindBySymbolTextBox.Text;
            try
            {
                var resultElement = currencyDetailDTOs.FirstOrDefault(element => element.symbol == symbolOfElement);
                CurrencyPopularityList.SelectedIndex = int.Parse(resultElement.rank) - 1;
            }
            catch { }
        }
    }
}
