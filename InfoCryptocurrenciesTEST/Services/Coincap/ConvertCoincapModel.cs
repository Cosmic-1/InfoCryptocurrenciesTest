using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoCryptocurrenciesTEST.Services.Coincap
{
    public static class ConvertCoincapModel
    {
        public static Exchange ToExchange(CoincapLibrary.Models.Exchange model)
        {
            return new Exchange
            {
                ExchangeUrl = model.ExchangeUrl,
                Name = model.Name,
                Volume = Convert.ToDecimal(model.VolumeUsd),
                PercentTotalVolume = Convert.ToDecimal(model.PercentTotalVolume),
                Rank = Convert.ToDecimal(model.Rank),
                Updated = DateTime.UnixEpoch.AddMilliseconds(Convert.ToDouble(model.Updated)),
            };
        }
        public static Money ToMoney(CoincapLibrary.Models.Money money)
        {
            return new Money
            {
                Id = money.Id,
                Symbol = money.Symbol,
                ConvertToUsd = Convert.ToDecimal(money.RateUsd),
                CurrencySymbol = money.CurrencySymbol,
                Type = money.Type
            };
        }

        public static Cryptocurrency ToCryptocurrency(CoincapLibrary.Models.Cryptocurrency model)
        {
            return new Cryptocurrency
            {
                ID = model.Id,
                Name = model.Name,
                Symbol = model.Symbol,
                MarketCap = Convert.ToDecimal(model.MarketCapUsd),
                Price = Convert.ToDecimal(model.PriceUsd),
                Volume24Hours = Convert.ToDecimal(model.VolumeUsd24Hr)
            };
        }

        public static DetailedCryptocurrecy ToDetailedCryptocurrency(
            CoincapLibrary.Models.Cryptocurrency model,
            CoincapLibrary.Models.CryptocurrencyHistory[]? histories = null,
            CoincapLibrary.Models.CryptocurrencyMarket[]? markets = null)
        {
            return new DetailedCryptocurrecy
            {
                ID = model.Id,
                Name = model.Name,
                Symbol = model.Symbol,
                MarketCap = Convert.ToDecimal(model.MarketCapUsd),
                Price = Convert.ToDecimal(model.PriceUsd),
                Volume24Hours = Convert.ToDecimal(model.VolumeUsd24Hr),
                Rank = Convert.ToDecimal(model.Rank),
                Explorer = model.Explorer,
                Exchanges = markets?.Select(ToCryptocurrencyExchange),
                Histories = histories?.Select(ToCryptocurrencyHistory),
            };
        }

        public static CryptocurrecyExchange ToCryptocurrencyExchange(CoincapLibrary.Models.CryptocurrencyMarket model)
        {
            return new CryptocurrecyExchange
            {
                ExchangeId = model.ExchangeId,
                Price = Convert.ToDecimal(model.PriceUsd),
                QuoteId = model.QuoteId,
                QuoteSymbol = model.QuoteSymbol,
                Volume24Hours = Convert.ToDecimal(model.VolumeUsd24Hr),
                VolumePercent = Convert.ToDecimal(model.VolumePercent)
            };
        }

        public static CryptocurrecyHistory ToCryptocurrencyHistory(CoincapLibrary.Models.CryptocurrencyHistory model)
        {
            return new CryptocurrecyHistory
            {
                DateAndTime = model.Date,
                Price = Convert.ToDecimal(model.PriceUsd),
            };
        }
    }
}
