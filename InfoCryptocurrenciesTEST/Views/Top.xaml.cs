using System;
using System.Collections;
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

namespace InfoCryptocurrenciesTEST.Views
{
    /// <summary>
    /// Interaction logic for Top.xaml
    /// </summary>
    public partial class Top : Page
    {
        public TopViewModel CryptocurrenciesViewModel { get; private set; } = new();
        public Top()
        {
            DataContext = CryptocurrenciesViewModel;
            InitializeComponent();
        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = e.AddedItems[0] as Cryptocurrency;
            if (item is not null)
            {
                var window = new DetailedWindow(item.ID);
                window.Show();
            }
        }
    }
}
