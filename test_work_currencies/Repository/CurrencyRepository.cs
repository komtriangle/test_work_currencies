using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using test_work_currencies.Models;

namespace test_work_currencies.Repository
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly string url= "https://www.cbr-xml-daily.ru/daily_json.js";

        public IEnumerable<Currency> GetCurrencies()
        {
            
            using (WebClient webclient = new WebClient())
            {
                string json;
                json = webclient.DownloadString(url);
                var obj = JObject.Parse(json);
                var valute = obj["Valute"];

                List<Currency> currencies = valute.Select(u => u.First.ToObject<Currency>()).ToList<Currency>();
                return currencies;
            }
           
        }

        public Currency GetCurrency(string ID)
        {
            using (WebClient webclient = new WebClient())
            {
                string json;
                json = webclient.DownloadString(url);
                var obj = JObject.Parse(json);
                var valute = obj["Valute"];
                Currency currencies = valute.Select(u => u.First.ToObject<Currency>())
                    .FirstOrDefault(o => o.ID == ID);
                return currencies;
            }
        }
    }
}
