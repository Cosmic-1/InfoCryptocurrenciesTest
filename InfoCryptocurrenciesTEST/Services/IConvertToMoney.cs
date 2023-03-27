using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoCryptocurrenciesTEST.Services
{
    public interface IConvertToMoney
    {
        Task<IEnumerable<Money>?> ConvertCryptocurrencyAsync(string cryptocurrencyId);
    }
}
