using InfoCryptocurrenciesTEST.Services;
using InfoCryptocurrenciesTEST.Services.Coincap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace InfoCryptocurrenciesTEST.ViewModels
{
    public class ExchangesViewModel : ViewModelBase
    {
        IExchange exchange;
        private IEnumerable<Exchange>? exchanges;

        public ExchangesViewModel()
        {
            exchange = new CoincapManager();
            Update();
        }

        public IEnumerable<Exchange>? Exchanges
        {
            get => exchanges;
            private set
            {
                exchanges = value;
                OnNotifyPropertyChanged(nameof(Exchanges));
            }
        }

        public void Update()
        {
            Dispatcher.CurrentDispatcher.Invoke(async () =>
            {
                Exchanges = await exchange.GetAllExchangesAsync();
            });
        }
    }
}
