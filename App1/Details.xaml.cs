using System.Windows;
using Windows.UI.Xaml.Navigation;

namespace App1
{
    public partial class Details : Windows.UI.Xaml.Controls.Page
    {
        public Details()
        {
            InitializeComponent();

            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           Title.Text = "Szczegóły waluty "+e.Parameter;
        }

        private void Back_Button(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), null);
        }      
    }
}
