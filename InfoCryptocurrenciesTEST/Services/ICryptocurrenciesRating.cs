using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoCryptocurrenciesTEST.Services
{
    public interface ICryptocurrenciesRating
    {
        Task<IEnumerable<Cryptocurrency>?> GetCryptocurrenciesAsync(string? cryptocurrencyName = null, int? limit = null, int? offset = null);
    }
}
