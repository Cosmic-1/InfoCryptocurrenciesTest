using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoCryptocurrenciesTEST.Services.Coincap
{
    public class CoincapManager : ICryptocurrenciesRating, IDetailedCryptocurrency, IAllMoney, IExchange
    {
        CoincapLibrary.AssetsPrice prices = new();
        CoincapLibrary.MoneyRates money = new();
        CoincapLibrary.CryptocurrencyExchanges exchanges = new();

        IEnumerable<Cryptocurrency>? cryptocurrencies;

        public IEnumerable<Cryptocurrency>? AllCryptocurrencies()
            => cryptocurrencies;

        public IEnumerable<Cryptocurrency>? Top10()
            => cryptocurrencies?.Take(10);

        public IEnumerable<Cryptocurrency>? Top20()
        => cryptocurrencies?.Take(20);

        public IEnumerable<Cryptocurrency>? Top100()
        => cryptocurrencies?.Take(100);


        public async Task<bool> UpdateAsync()
        {
            cryptocurrencies = await GetCryptocurrenciesAsync(1000, 0);

            return cryptocurrencies is not null;
        }

        public async Task<IEnumerable<Cryptocurrency>?> SearchAsync(string value)
        {
            var data = await prices.GetCryptocurrenciesAsync(search: value);
            return data?.Select(ConvertCoincapModel.ToCryptocurrency);
        }

        public async Task<DetailedCryptocurrecy?> GetDetailedCryptocurrecyAsync(string cryptocurrencyId, int? limitMarkets = null, int? offsetMarket = null)
        {
            var coin = await prices.GetCryptocurrencyAsync(cryptocurrencyId);
            var markets = await prices.GetCryptocurrencyMarketsAsync(cryptocurrencyId, limitMarkets, offsetMarket);
            var histories = await prices.GetCryptocurrencyHistoryAsync(cryptocurrencyId, CoincapLibrary.TimeInterval.OneDay);

            return coin is not null
                ? ConvertCoincapModel.ToDetailedCryptocurrency(coin, histories, markets)
                : null;
        }
        private async Task<IEnumerable<Cryptocurrency>?> GetCryptocurrenciesAsync(int limit, int offset)
        {
            var data = await prices.GetCryptocurrenciesAsync(limit: limit, offset: offset);

            return data?.Select(ConvertCoincapModel.ToCryptocurrency);
        }

        public async Task<IEnumerable<Money>?> GetAllMoneyAsync()
        {
            var allMoney = await money.GetMoneyAsync();

            return allMoney?.Select(ConvertCoincapModel.ToMoney);
        }

        public async Task<Money?> GetMoneyAsync(string name)
        {
            var moneyM = await money.GetSingleMoneyAsync(name);

            return moneyM is not null ? ConvertCoincapModel.ToMoney(moneyM) : null;
        }

        public async Task<IEnumerable<Exchange>?> GetAllExchangesAsync()
        {
            var data = await exchanges.GetExchangesAsync();
            return data?.Select(ConvertCoincapModel.ToExchange);
        }

        public async Task<Exchange?> GetSingleExchangeAsync(string name)
        {
            var data = await exchanges.GetSingleExchangeAsync(name);
            return ConvertCoincapModel.ToExchange(data);
        }
    }
}
