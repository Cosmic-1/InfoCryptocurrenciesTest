namespace CoincapLibrary.Models
{
    public class CryptocurrencyMarket
    {
        /// <summary>
        /// unique identifier for exchange
        /// </summary>
        [JsonPropertyName("exchangeId")]
        public string? ExchangeId { get; set; }
        /// <summary>
        /// unique identifier for this asset, base is asset purchased
        /// </summary>
        [JsonPropertyName("baseId")]
        public string? BaseId { get; set; }
        /// <summary>
        /// unique identifier for this asset, quote is asset used to purchase based
        /// </summary>
        [JsonPropertyName("quoteId")]
        public string? QuoteId { get; set; }
        /// <summary>
        /// most common symbol used to identify asset, base is asset purchased
        /// </summary>
        [JsonPropertyName("baseSymbol")]
        public string? BaseSymbol { get; set; }
        /// <summary>
        /// most common symbol used to identify asset, quote is asset used to purchase base
        /// </summary>
        [JsonPropertyName("quoteSymbol")]
        public string? QuoteSymbol { get; set; }
        /// <summary>
        /// volume transacted on this market in last 24 hours
        /// </summary>
        [JsonPropertyName("volumeUsd24Hr")]
        public string? VolumeUsd24Hr { get; set; }
        /// <summary>
        /// the amount of quote asset traded for one unit of base asset
        /// </summary>
        [JsonPropertyName("priceUsd")]
        public string? PriceUsd { get; set; }
        /// <summary>
        /// percent of quote asset volume
        /// </summary>
        [JsonPropertyName("volumePercent")]
        public string? VolumePercent { get; set; }
    }
}
