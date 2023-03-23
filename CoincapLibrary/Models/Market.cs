namespace CoincapLibrary.Models
{
    public class Market
    {
        /// <summary>
        /// unique identifier for exchange
        /// </summary>
        [JsonPropertyName("exchangeId")]
        public string? ExchangeId { get; set; }
        /// <summary>
        /// rank is in ascending order - this number represents the amount of volume transacted by this market in relation to other markets on that exchange
        /// </summary>
        [JsonPropertyName("rank")]
        public string? Rank { get; set; }
        /// <summary>
        /// most common symbol used to identify asset, base is asset purchased
        /// </summary>
        [JsonPropertyName("baseSymbol")]
        public string? BaseSymbol { get; set; }
        /// <summary>
        /// unique identifier for this asset, base is asset purchased
        /// </summary>
        [JsonPropertyName("baseId")]
        public string? BaseId { get; set; }
        /// <summary>
        /// most common symbol used to identify asset, quote is asset used to purchase base
        /// </summary>
        [JsonPropertyName("quoteSymbol")]
        public string? QuoteSymbol { get; set; }
        /// <summary>
        /// unique identifier for this asset, quote is asset used to purchase base
        /// </summary>
        [JsonPropertyName("quoteId")]
        public string? QuoteId { get; set; }
        /// <summary>
        /// the amount of quote asset traded for one unit of base asset
        /// </summary>
        [JsonPropertyName("priceQuote")]
        public string? PriceQuote { get; set; }
        /// <summary>
        /// quote price translated to USD
        /// </summary>
        [JsonPropertyName("priceUsd")]
        public string? PriceUsd { get; set; }
        /// <summary>
        /// volume transacted on this market in last 24 hours
        /// </summary>
        [JsonPropertyName("volumeUsd24Hr")]
        public string? VolumeUsd24Hr { get; set; }
        /// <summary>
        /// the amount of daily volume a single market transacts in relation to total daily volume of all markets on the exchange
        /// </summary>
        [JsonPropertyName("percentExchangeVolume")]
        public string? PercentExchangeVolume { get; set; }
        /// <summary>
        /// number of trades on this market in the last 24 hours
        /// </summary>
        [JsonPropertyName("tradesCount24Hr")]
        public string? TradesCount24Hr { get; set; }
        /// <summary>
        /// UNIX timestamp (milliseconds) since information was received from this particular market
        /// </summary>
        [JsonPropertyName("updated")]
        public decimal? Updated { get; set; }
    }
}
