namespace CoincapLibrary
{
    /// <summary>
    /// The /exchanges endpoint offers an understanding into the where cryptocurrency is being exchanged and offers high-level information on those exchanges.
    /// CoinCap strives to provide transparency in the recency of our exchange data. 
    /// For that purpose you will find an "updated" key for each exchange. For more details into coin pairs and volume, see the /markets endpoint.
    /// </summary>
    public class CryptocurrencyExchanges : CoincapBase
    {
        protected override string UriBase => "https://api.coincap.io/v2/exchanges";

        public async Task<Exchange[]?> GetExchangesAsync()
        {
            return await DeserializeDataAsync<Exchange[]>(new Uri(UriBase));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">	exchange id (binance)</param>
        /// <returns></returns>
        public async Task<Exchange?> GetSingleExchangeAsync(string exchangeId)
        {
            var uriBuilder = new UriBuilder(UriBase);
            uriBuilder.Path += $"/{exchangeId}";

            return await DeserializeDataAsync<Exchange>(uriBuilder.Uri);
        }
    }
}
