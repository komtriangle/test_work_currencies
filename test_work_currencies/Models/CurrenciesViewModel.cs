using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_work_currencies.Models
{
    public class CurrenciesViewModel
    {
        public IEnumerable<Currency> Currencies { get; set; }
        public PageViewModel PageViewModel { get; set; }

    }
}
