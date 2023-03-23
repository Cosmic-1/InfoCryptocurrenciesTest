namespace CoincapLibrary
{
    /// <summary>
    /// Take a closer look into exchanges with the /markets endpoint. 
    /// Similar to the /exchanges endpoint, we strive to offer transparency into how real-time our data is with a key identifying when the market was last updated. 
    /// For a historical view on how a market has performed, see the /candles endpoint. 
    /// All market data represents actual trades processed, orders on an exchange are not represented. 
    /// Data received from individual markets is used to calculate the current price of an asset.
    /// </summary>
    public class FilterMarkets : CoincapBase
    {
        protected override string UriBase => "https://api.coincap.io/v2/markets";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exchangeId">search by exchange id</param>
        /// <param name="baseSymbol">returns all containing the base symbol</param>
        /// <param name="quoteSymbol">returns all containing the quote symbol</param>
        /// <param name="baseId">returns all containing the base id</param>
        /// <param name="quoteId">returns all containing the quote id</param>
        /// <param name="assetSymbol">returns all assets containing symbol (base and quote)</param>
        /// <param name="assetId">returns all assets containing id (base and quote)</param>
        /// <param name="limit">max limit of 2000</param>
        /// <param name="offset">offset</param>
        /// <returns></returns>
        public async Task<Market[]?> GetMarketsAsync(
            string? exchangeId = null,
            string? baseSymbol = null,
            string? quoteSymbol = null,
            string? baseId = null,
            string? quoteId = null,
            string? assetSymbol = null,
            string? assetId = null,
            int? limit = null,
            int? offset = null)
        {
            var queries = new Dictionary<string, string>() {
                {nameof(exchangeId), exchangeId },
                {nameof(baseSymbol), baseSymbol},
                {nameof(quoteSymbol), quoteSymbol},
                {nameof(baseId), baseId},
                {nameof(quoteId), quoteId},
                {nameof(assetSymbol), assetSymbol},
                {nameof(assetId), assetId},
                {nameof(limit), ConvertStructToString(limit)},
                {nameof(offset), ConvertStructToString(offset)}
            };

            var uriBuilder = new UriBuilder(UriBase);
            uriBuilder.Query = queries.GenerateUriQueries();

            return await DeserializeDataAsync<Market[]>(uriBuilder.Uri);
        }
    }
}
