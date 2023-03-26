using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoCryptocurrenciesTEST.Services
{
    public interface ICryptocurrenciesRating
    {
        IEnumerable<Cryptocurrency>? AllCryptocurrencies();
        IEnumerable<Cryptocurrency>? Top10();
        IEnumerable<Cryptocurrency>? Top20();
        IEnumerable<Cryptocurrency>? Top100();
        Task<IEnumerable<Cryptocurrency>?> SearchAsync(string value);
        Task<bool> UpdateAsync();
    }
}
