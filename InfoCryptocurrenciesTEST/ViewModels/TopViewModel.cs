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
            UpdateDataCommand = new UpdateDataCommand(Update);
            SearchCommand = new SearchCommand(SearchData);

            manager = new CoincapManager();
            Update("10");
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
                Cryptocurrencies = await manager.SearchAsync((string)parameter);
            });
        }

        private void Update(object? parameter)
        {
            Dispatcher.CurrentDispatcher.Invoke(async () =>
            {
                var result = await manager.UpdateAsync();
                if (result)
                {
                    Cryptocurrencies = parameter switch
                    {
                        "100" => manager.Top100(),
                        "20" => manager.Top20(),
                        "10" => manager.Top10(),
                        _ => manager.AllCryptocurrencies(),
                    };
                }
            });
        }
    }
}
