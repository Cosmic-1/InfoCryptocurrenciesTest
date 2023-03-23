namespace CoincapLibrary.Models
{
    public class Money
    {
        /// <summary>
        /// unique identifier for asset or fiat
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; }
        /// <summary>
        /// most common symbol used to identify asset or fiat
        /// </summary>
        [JsonPropertyName("symbol")]
        public string? Symbol { get; set; }
        /// <summary>
        /// currency symbol used to identify asset or fiat
        /// </summary>
        [JsonPropertyName("currencySymbol")]
        public string? CurrencySymbol { get; set; }
        /// <summary>
        /// rate conversion to USD
        /// </summary>
        [JsonPropertyName("rateUsd")]
        public string? RateUsd { get; set; }
        /// <summary>
        /// type of currency - fiat or crypto
        /// </summary>
        [JsonPropertyName("type")]
        public string? Type { get; set; }
    }
}
