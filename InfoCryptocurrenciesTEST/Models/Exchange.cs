using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InfoCryptocurrenciesTEST.Models
{
    public class Exchange
    {
        public string? Name { get; set; }
        public decimal? Rank { get; set; }
        public decimal? PercentTotalVolume { get; set; }
        public decimal? Volume { get; set; }
        public string? ExchangeUrl { get; set; }
        public DateTime? Updated { get; set; }
    }
}
