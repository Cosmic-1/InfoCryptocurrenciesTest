namespace CoincapLibrary.Models
{
    /// <summary>
    /// Model for api.coincap.io/v2/assets
    /// </summary>
    public class Cryptocurrency
    {
        /// <summary>
        /// unique identifier for asset
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; }
        /// <summary>
        /// rank is in ascending order - this number is directly associated with the marketcap whereas the highest marketcap receives rank 1
        /// </summary>
        [JsonPropertyName("rank")]
        public string? Rank { get; set; }
        /// <summary>
        /// most common symbol used to identify this asset on an exchange
        /// </summary>
        [JsonPropertyName("symbol")]
        public string? Symbol { get; set; }
        /// <summary>
        /// proper name for asset
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        /// <summary>
        /// available supply for trading
        /// </summary>
        [JsonPropertyName("sympply")]
        public string? Supply { get; set; }
        /// <summary>
        /// total quantity of asset issued
        /// </summary>
        [JsonPropertyName("maxSupply")]
        public string? MaxSupply { get; set; }
        /// <summary>
        /// supply x price
        /// </summary>
        [JsonPropertyName("marketCapUsd")]
        public string? MarketCapUsd { get; set; }
        /// <summary>
        /// quantity of trading volume represented in USD over the last 24 hours
        /// </summary>
        [JsonPropertyName("volumeUsd24Hr")]
        public string? VolumeUsd24Hr { get; }
        /// <summary>
        /// volume-weighted price based on real-time market data, translated to USD
        /// </summary>
        [JsonPropertyName("priceUsd")]
        public string? PriceUsd { get; }
        /// <summary>
        /// the direction and value change in the last 24 hours
        /// </summary>
        [JsonPropertyName("changePercent24Hr")]
        public string? ChangePercent24Hr { get; set; }
        /// <summary>
        /// Volume Weighted Average Price in the last 24 hours
        /// </summary>
        [JsonPropertyName("vwap24Hr")]
        public string? Vwap24Hr { get; set; }
        /// <summary>
        /// An official website or an unofficial page from another website
        /// </summary>
        [JsonPropertyName("explorer")]
        public string? Explorer { get; set; }
    }
}
