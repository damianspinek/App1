using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string[] stringArray = new string[6];
        private ObservableCollection<Currency> latestCurrency;
        public MainPage()
        {
            loadData();
            InitializeComponent();
        }

        private async void loadData()
        {
            var result = CurrencyPArser.downloadXml();
            await result;
            latestCurrency = new ObservableCollection<Currency>(result.Result);
            CurrencyListBox.ItemsSource = latestCurrency;
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Hello!!!!");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("HEst");
            this.Frame.Navigate(typeof(Details), latestCurrency[0].kodWaluty);
            
        }

        private void CloseApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void CurrencyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listbox = (ListBox)sender;
            this.Frame.Navigate(typeof(Details), latestCurrency[listbox.SelectedIndex].kodWaluty);
        }
    }
}
