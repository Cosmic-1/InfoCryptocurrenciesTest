using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InfoCryptocurrenciesTEST.Models
{
    public class DetailedCryptocurrecy: Cryptocurrency
    {
        public decimal? Rank { get; set; }
        public string? Explorer { get; set; }
        public IEnumerable<CryptocurrecyHistory>? Histories { get; set; }
        public IEnumerable<CryptocurrecyExchange>? Exchanges { get; set; }
    }

    public class CryptocurrecyHistory
    {
        public decimal? Price { get; set; }
        public DateTime? DateAndTime { get; set; }
    }

    public class CryptocurrecyExchange
    {
        public string? ExchangeId { get; set; }
        public string? QuoteId { get; set; }
        public string? QuoteSymbol { get; set; }
        public decimal? Volume24Hours { get; set; }
        public decimal? Price { get; set; }
        public decimal? VolumePercent { get; set; }
    }
}
