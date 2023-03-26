using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InfoCryptocurrenciesTEST.Models
{
    public class Money
    {
        public string? Id { get; set; }
        public string? Symbol { get; set; }
        public string? CurrencySymbol { get; set; }
        public decimal? ConvertToUsd { get; set; }
        public string? Type { get; set; }
    }
}
