using CryptoCompass.DTO.Models;
using CryptoCompass.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CryptoCompass
{
    /// <summary>
    /// Interaction logic for CurrencyPopularityPage.xaml
    /// </summary>
    public partial class CurrencyPopularityPage : Page
    {
        private CurrencyService currencyService;
        private IEnumerable<CurrencyDetailDTO> currencyDetailDTOs;
        public CurrencyPricesDTO CurrencyPricesDTO;

        public CurrencyPopularityPage()
        {
            InitializeComponent();

            currencyService = new CurrencyService();
        }
            
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            currencyDetailDTOs = await currencyService.GetCurrencyPricesAsync();
            this.DataContext = currencyDetailDTOs;
        }

        private void ListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (CurrencyPopularityList.SelectedItems.Count == 0)
                CurrencyPopularityList.SelectedIndex = 0;

            NavigationService.Navigate(new Uri("/CurrencyDetailsPage.xaml", UriKind.Relative));
        }
    }
}
