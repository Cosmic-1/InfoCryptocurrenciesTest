namespace CoincapLibrary.Models
{
    public class Exchange
    {
        /// <summary>
        /// unique identifier for exchange
        /// </summary>
        [JsonPropertyName("exchangeId")]
        public string? ExchangeId { get; set; }
        /// <summary>
        /// proper name of exchange
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        /// <summary>
        /// rank is in ascending order - this number is directly associated with the total exchange volume whereas the highest volume exchange receives rank 1
        /// </summary>
        [JsonPropertyName("rank")]
        public string? Rank { get; set; }
        /// <summary>
        /// the amount of daily volume a single exchange transacts in relation to total daily volume of all exchanges
        /// </summary>
        [JsonPropertyName("percentTotalVolume")]
        public string? PercentTotalVolume { get; set; }
        /// <summary>
        /// daily volume represented in USD
        /// </summary>
        [JsonPropertyName("volumeUsd")]
        public string? VolumeUsd { get; set; }
        /// <summary>
        /// number of trading pairs (or markets) offered by exchange
        /// </summary>
        [JsonPropertyName("tradingPairs")]
        public string? TradingPairs { get; set; }
        /// <summary>
        /// true/false, true = trade socket available, false = trade socket unavailable
        /// </summary>
        [JsonPropertyName("socket")]
        public bool? Socket { get; set; }
        /// <summary>
        /// website to exchange
        /// </summary>
        [JsonPropertyName("exchangeUrl")]
        public string? ExchangeUrl { get; set; }
        /// <summary>
        /// UNIX timestamp (milliseconds) since information was received from this exchange
        /// </summary>
        [JsonPropertyName("updated")]
        public decimal? Updated { get; set; }
    }
}
