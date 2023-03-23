using System.IO;

namespace CoincapLibrary
{
    /// <summary>
    /// The asset price is a volume-weighted average calculated by collecting ticker data from exchanges. 
    /// Each exchange contributes to this price in relation to their volume, 
    /// meaning higher volume exchanges have more affect on this global price.
    /// All values are translated into USD (United States Dollar) 
    /// and can be translated into other units of measurement through the /rates endpoint.
    /// </summary>
    public class AssetsPrice : CoincapBase
    {
        private static Dictionary<TimeInterval, string> intervalDictionary = new()
        {
            { TimeInterval.OneMinute, "m1" },
            { TimeInterval.FiveMinutes, "m5" },
            { TimeInterval.FifteenMinutes, "m15"},
            { TimeInterval.ThirtyMinutes, "m30"},
            { TimeInterval.OneHour, "h1" },
            { TimeInterval.TwoHours, "h2"},
            { TimeInterval.SixHours, "h6"},
            { TimeInterval.TwelveHours, "h12"},
            { TimeInterval.OneDay, "d1"}
        };
        protected override string UriBase { get; } = "https://api.coincap.io/v2/assets";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="search">search by asset id (bitcoin) or symbol (BTC)</param>
        /// <param name="ids">query with multiple ids=bitcoin,ethereum,monero</param>
        /// <param name="limit">max limit of 2000</param>
        /// <param name="offset">offset</param>
        /// <returns>Cryptocurrency[]</returns>
        public async Task<Cryptocurrency[]?> GetCryptocurrenciesAsync(
            string? search = null,
            string? ids = null,
            int? limit = null,
            int? offset = null)
        {
            var uriQueries = new Dictionary<string, string>() {
                { nameof(search), search},
                { nameof(ids), ids},
                { nameof(limit), ConvertStructToString(limit)},
                { nameof(offset), ConvertStructToString(offset)}
            };

            var uriBuilder = new UriBuilder(UriBase);
            uriBuilder.Query = uriQueries.GenerateUriQueries();

            return await DeserializeDataAsync<Cryptocurrency[]>(uriBuilder.Uri);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">asset id (bitcoin)</param>
        /// <returns></returns>

        public async Task<Cryptocurrency?> GetCryptocurrencyAsync(string cryptocurrencyId)
        {
            var uriBuilder = new UriBuilder(UriBase);
            uriBuilder.Path += $"/{cryptocurrencyId}/";

            return await DeserializeDataAsync<Cryptocurrency>(uriBuilder.Uri);
        }
        /// <summary>
        /// Interval: m1, m5, m15, m30, h1, h2, h6, h12, d1
        /// </summary>
        /// <param name="name">point-in-time interval. minute and hour intervals represent price at that time, the day interval represents average of 24 hour periods (timezone: UTC)</param>
        /// <param name="interval">UNIX time in milliseconds. omitting will return the most recent asset history. If start is supplied, end is required and vice versa</param>
        /// <returns></returns>
        public async Task<CryptocurrencyHistory[]?> GetCryptocurrencyHistoryAsync(string cryptocurrencyId, TimeInterval interval)
        {
            var uriBuilder = new UriBuilder(UriBase);
            uriBuilder.Path += $"/{cryptocurrencyId}/history";
            uriBuilder.Query = $"{nameof(interval)}={intervalDictionary[interval]}";

            return await DeserializeDataAsync<CryptocurrencyHistory[]>(uriBuilder.Uri);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">asset id (bitcoin)</param>
        /// <param name="limit">max limit of 2000</param>
        /// <param name="offset">offset</param>
        /// <returns></returns>
        public async Task<CryptocurrencyMarket[]?> GetCryptocurrencyMarketsAsync(
            string cryptocurrencyId,
            int? limit = null,
            int? offset = null)
        {
            var uriQueries = new Dictionary<string, string>() {
                { nameof(limit), ConvertStructToString(limit) },
                { nameof(offset), ConvertStructToString(offset) }
            };

            var uriBuilder = new UriBuilder(UriBase);
            uriBuilder.Path += $"/{cryptocurrencyId}/markets";
            uriBuilder.Query = uriQueries.GenerateUriQueries();

            return await DeserializeDataAsync<CryptocurrencyMarket[]>(uriBuilder.Uri);
        }

    }

    public enum TimeInterval : byte
    {
        OneMinute,
        FiveMinutes,
        FifteenMinutes,
        ThirtyMinutes,
        OneHour,
        TwoHours,
        SixHours,
        TwelveHours,
        OneDay
    }
}