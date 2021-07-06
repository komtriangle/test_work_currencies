using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using test_work_currencies.Models;
using test_work_currencies.Repository;

namespace test_work_currencies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICurrencyRepository _repository;

        public HomeController(ILogger<HomeController> logger, ICurrencyRepository repository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public ActionResult currencies(int Page=1)
        {
            int PageSize = 5;
            var Currencies = _repository.GetCurrencies();
            PageViewModel pageViewModel = new PageViewModel(Currencies.Count(), Page, PageSize);
            CurrenciesViewModel viewModel = new CurrenciesViewModel()
            {
                PageViewModel = pageViewModel,
                Currencies = Currencies.Skip((Page - 1) * PageSize).Take(PageSize)
            };
            return View(viewModel);
        }

        public ActionResult currency(string ID)
        {
            var Currency = _repository.GetCurrency(ID);
            if(Currency == null)
            {
                return View("ErrorCurrency");
            }
            return View(Currency);
        }
    }
}
