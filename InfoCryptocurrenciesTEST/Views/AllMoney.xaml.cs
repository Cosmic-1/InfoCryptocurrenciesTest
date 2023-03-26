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

namespace InfoCryptocurrenciesTEST.Views
{
    /// <summary>
    /// Interaction logic for AllMoney.xaml
    /// </summary>
    public partial class AllMoney : Page
    {
        public AllMoneyViewModel AllMoneyViewModel { get; private set; } = new();
        public AllMoney()
        {
            DataContext = AllMoneyViewModel;
            InitializeComponent();
        }
    }
}
