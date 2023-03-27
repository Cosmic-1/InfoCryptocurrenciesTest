using CoincapLibrary.Models;

namespace CoincapLibrary
{
    /// <summary>
    /// All prices on the CoinCap API are standardized in USD (United States Dollar). 
    /// To make translating to other values easy, CoinCap now offers a Rates endpoint. 
    /// We offer fiat and top cryptocurrency translated rates. Fiat rates are available through OpenExchangeRates.org.
    /// </summary>
    public class MoneyRates : CoincapBase
    {
        protected override string UriBase { get; set; } = "https://api.coincap.io/v2/rates";

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<Money[]?> GetMoneyAsync()
        {
            return await DeserializeDataAsync<Money[]>(new Uri(UriBase));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="moneyId">asset id (bitcoin)</param>
        /// <returns></returns>
        public async Task<Money?> GetSingleMoneyAsync(string moneyId)
        {
            var uriBuilder = new UriBuilder(UriBase);
            uriBuilder.Path += $"/{moneyId}";

            return await DeserializeDataAsync<Money>(uriBuilder.Uri);
        }
    }
}
