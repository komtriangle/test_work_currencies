using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_work_currencies.Models;

namespace test_work_currencies.Repository
{
    public interface ICurrencyRepository
    {
        IEnumerable<Currency> GetCurrencies();
        Currency GetCurrency(string ID);
    }
}
