using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoCryptocurrenciesTEST.Services
{
    public interface IAllMoney
    {
        Task<IEnumerable<Money>?> GetAllMoneyAsync();
        Task<Money?> GetMoneyAsync(string name);
    }
}
