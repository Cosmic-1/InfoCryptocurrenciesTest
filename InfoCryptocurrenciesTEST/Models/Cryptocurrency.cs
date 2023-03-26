using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoCryptocurrenciesTEST.Models
{
    public class Cryptocurrency
    {
        public string? ID { get; set; }
        public string? Name { get; set; }
        public string? Symbol { get; set; }
        public decimal? Price { get; set; }
        public decimal? MarketCap { get; set; }
        public decimal? Volume24Hours { get; set; }
    }
}
