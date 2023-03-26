using InfoCryptocurrenciesTEST.Commands;
using InfoCryptocurrenciesTEST.Services;
using InfoCryptocurrenciesTEST.Services.Coincap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace InfoCryptocurrenciesTEST.ViewModels
{
    public class DetailedViewModel : ViewModelBase
    {
        DetailedCryptocurrecy? detailedCryptocurrecy;
        IDetailedCryptocurrency manager;

        public DetailedCryptocurrecy? DetailedCryptocurrecy
        {
            get => detailedCryptocurrecy;
            private set
            {
                detailedCryptocurrecy = value;
                base.OnNotifyPropertyChanged(nameof(DetailedCryptocurrecy));
            }
        }

        public ICommand? UpdateCommand { get; private set; }

        public DetailedViewModel()
        {
            UpdateCommand = new UpdateDataCommand(Update);
            manager = new CoincapManager();
        }

        public void Update(object? parameter)
        {
            Dispatcher.CurrentDispatcher.Invoke(async () =>
            {
                DetailedCryptocurrecy = await manager.GetDetailedCryptocurrecyAsync((string)parameter);
            });
        }
    }
}
