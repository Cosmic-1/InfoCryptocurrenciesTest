using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoCryptocurrenciesTEST.Services
{
    public interface IDetailedCryptocurrency
    {
        Task<DetailedCryptocurrecy?> GetDetailedCryptocurrecyAsync(string name, int? limit = null, int? offset = null);
    }
}
