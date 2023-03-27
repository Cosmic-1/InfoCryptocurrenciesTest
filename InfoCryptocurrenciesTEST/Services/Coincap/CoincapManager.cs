using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoCryptocurrenciesTEST.Services.Coincap
{
    public class CoincapManager : ICryptocurrenciesRating, IDetailedCryptocurrency, IConvertToMoney, IExchange
    {
        CoincapLibrary.AssetsPrice prices = new();
        CoincapLibrary.MoneyRates money = new();
        CoincapLibrary.CryptocurrencyExchanges exchanges = new();

        public async Task<IEnumerable<Cryptocurrency>?> GetCryptocurrenciesAsync(string? cryptocurrencyName = null, int? limit = null, int? offset = null)
        {
            var data = await prices.GetCryptocurrenciesAsync(search: cryptocurrencyName, limit: limit, offset: offset);

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

        public async Task<IEnumerable<Money>?> ConvertCryptocurrencyAsync(string cryptocurrencyId)
        {
            var crypto = await prices.GetCryptocurrencyAsync(cryptocurrencyId);
            var moneyModels = await money.GetMoneyAsync();

            if (crypto is null || moneyModels is null)
                return null;

            var converted = moneyModels.Select((m) =>
            {
                var convertModel = ConvertCoincapModel.ToMoney(m);

                convertModel.ConvertToUsd = Convert.ToDecimal(crypto.PriceUsd) / convertModel.ConvertToUsd;

                return convertModel;
            });

            return converted;
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
