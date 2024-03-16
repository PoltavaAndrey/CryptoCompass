using CryptoCompass.DTO.Models;
using CryptoCompass.Services.Services;
using System.Windows.Controls;

namespace CryptoCompass
{
    /// <summary>
    /// Interaction logic for CurrencyDetailsPage.xaml
    /// </summary>
    public partial class CurrencyDetailsPage : Page
    {
        public CurrencyDetailsPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new System.Uri("/CurrencyPopularityPage.xaml", System.UriKind.Relative));
        }
    }
}
