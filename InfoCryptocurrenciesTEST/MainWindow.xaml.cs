using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        private void MoneyMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Source = new Uri("./Views/AllMoney.xaml", UriKind.Relative);
        }

        private void ExchangesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Source = new Uri("./Views/Exchanges.xaml", UriKind.Relative);
        }
    }
}
