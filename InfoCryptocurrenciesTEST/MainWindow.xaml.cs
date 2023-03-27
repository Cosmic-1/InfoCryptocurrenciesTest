using System;
using System.Windows;

namespace InfoCryptocurrenciesTEST
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TopMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Source = new Uri("./Views/Top.xaml", UriKind.Relative);
        }

        private void ConvertMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Source = new Uri("./Views/Convert.xaml", UriKind.Relative);
        }

        private void ExchangesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Source = new Uri("./Views/Exchanges.xaml", UriKind.Relative);
        }
    }
}
