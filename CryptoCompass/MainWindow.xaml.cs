using CryptoCompass.DTO.Models;
using CryptoCompass.Services.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CryptoCompass
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CurrencyService currencyService;
        private CurrencyDetailDTO CurrencyDetailDTO;
        private IEnumerable<CurrencyDetailDTO> currencyDetailDTOs;
        private CurrencyPricesDTO CurrencyPricesDTO;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = CurrencyDetailDTO;

            currencyService = new CurrencyService();
            CurrencyDetailDTO = new CurrencyDetailDTO();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            CurrencyDetailDTO = await currencyService.GetCurrencyDetailsAsync("bitcoin");
            this.DataContext = CurrencyDetailDTO;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CurrencyPricesDTO = await currencyService.GetCurrencyPricesAsync();
            currencyDetailDTOs = CurrencyPricesDTO.data.Take(10);
            this.DataContext = currencyDetailDTOs;
        }
    }
}
