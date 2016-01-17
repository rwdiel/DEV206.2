using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ViewModel.UniversalWindows
{
    public sealed partial class OrderPage : Page
    {
        public OrderPage()
        {
            this.InitializeComponent();
        }

        private void MainPage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
