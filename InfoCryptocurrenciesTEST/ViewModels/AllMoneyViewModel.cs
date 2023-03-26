using InfoCryptocurrenciesTEST.Services;
using InfoCryptocurrenciesTEST.Services.Coincap;
using InfoCryptocurrenciesTEST.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace InfoCryptocurrenciesTEST.ViewModels
{
    public class AllMoneyViewModel : ViewModelBase
    {
        IAllMoney manager;
        private IEnumerable<Money>? allMoney;

        public AllMoneyViewModel()
        {
            manager = new CoincapManager();
            Update();
        }

        public IEnumerable<Money>? AllMoney
        {
            get => allMoney;
            private set
            {
                allMoney = value;
                base.OnNotifyPropertyChanged(nameof(AllMoney));
            }
        }

        public void Update()
        {
            Dispatcher.CurrentDispatcher.Invoke(async () =>
            {
                AllMoney = await manager.GetAllMoneyAsync();
            });
        }
    }
}
