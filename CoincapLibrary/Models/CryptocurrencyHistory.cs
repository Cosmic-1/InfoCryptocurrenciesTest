namespace CoincapLibrary.Models
{
    public class CryptocurrencyHistory
    {
        /// <summary>
        /// volume-weighted price based on real-time market data, translated to USD
        /// </summary>
        [JsonPropertyName("priceUsd")]
        public string? PriceUsd { get; set; }
        /// <summary>
        /// timestamp in UNIX in milliseconds
        /// </summary>
        [JsonPropertyName("time")]
        public decimal? Time { get; set; }

        /// <summary>
        /// Date and time
        /// </summary>
        [JsonPropertyName("date")]
        public DateTime? Date { get; set; }
    }
}
