using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoCryptocurrenciesTEST.Services
{
    public interface IExchange
    {
        Task<IEnumerable<Exchange>?> GetAllExchangesAsync();
        Task<Exchange?> GetSingleExchangeAsync(string name);
    }
}
