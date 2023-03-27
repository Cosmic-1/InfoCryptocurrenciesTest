using InfoCryptocurrenciesTEST.Commands;
using InfoCryptocurrenciesTEST.Services;
using InfoCryptocurrenciesTEST.Services.Coincap;
using InfoCryptocurrenciesTEST.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace InfoCryptocurrenciesTEST.ViewModels
{
    public class ConvertViewModel : ViewModelBase
    {
        IConvertToMoney manager;
        IEnumerable<Money>? allMoney;

        public ICommand ConvertCommand { get; set; }

        public ConvertViewModel()
        {
            manager = new CoincapManager();
            ConvertCommand = new ConvertCommand(Update);
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

        private void Update(object? parameter)
        {
            Dispatcher.CurrentDispatcher.Invoke(async () =>
            {
                AllMoney = await manager.ConvertCryptocurrencyAsync(parameter as string);
            });
        }
    }
}
