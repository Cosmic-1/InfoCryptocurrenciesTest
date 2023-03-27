using InfoCryptocurrenciesTEST.Commands;
using InfoCryptocurrenciesTEST.Services;
using InfoCryptocurrenciesTEST.Services.Coincap;
using Microsoft.Windows.Themes;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace InfoCryptocurrenciesTEST.ViewModels
{
    public class TopViewModel : ViewModelBase
    {
        ICryptocurrenciesRating manager;

        public TopViewModel()
        {
            UpdateDataCommand = new UpdateDataCommand(UpdateData);
            SearchCommand = new SearchCommand(SearchData);

            manager = new CoincapManager();

            UpdateData("10");
        }

        public ICommand UpdateDataCommand { get; private set; }
        public ICommand SearchCommand { get; private set; }

        IEnumerable<Cryptocurrency>? cryptocurrencies;
        public IEnumerable<Cryptocurrency>? Cryptocurrencies
        {
            get => cryptocurrencies;
            private set
            {
                cryptocurrencies = value;
                OnNotifyPropertyChanged(nameof(Cryptocurrencies));
            }
        }

        private void SearchData(object? parameter)
        {
            Dispatcher.CurrentDispatcher.Invoke(async () =>
            {
                Cryptocurrencies = await manager.GetCryptocurrenciesAsync(cryptocurrencyName: parameter as string);
            });
        }

        private void UpdateData(object? parameter)
        {
            Dispatcher.CurrentDispatcher.Invoke(async () =>
            {
                Cryptocurrencies = parameter switch
                {
                    "100" => await manager.GetCryptocurrenciesAsync(limit: 100, offset: 0),
                    "20" => await manager.GetCryptocurrenciesAsync(limit: 20, offset: 0),
                    "10" => await manager.GetCryptocurrenciesAsync(limit: 10, offset: 0),
                    _ => await manager.GetCryptocurrenciesAsync(limit: 1000, offset: 0),
                };
            });
        }
    }
}
