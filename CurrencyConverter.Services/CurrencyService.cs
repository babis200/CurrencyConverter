using CurrencyConverter.Models;

using Microsoft.Extensions.Configuration;

using Newtonsoft.Json;

using RestSharp;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CurrencyConverter.Services
{
    public class CurrencyService
    {
        private string _apiKey;
        public CurrencyService(string apiKey)
        {
            _apiKey = apiKey;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public async Task<ExchangeRate> HistoricalExchangeRate(DateTime date, string from)
        {

            var client = new RestClient($"https://api.fastforex.io/historical?api_key={_apiKey}");
            var request = new RestRequest();
            request.AddHeader("Accept", "application/json");
            request.AddParameter("date", date.ToString("yyyy-MM-dd"));
            request.AddParameter("from", from);
            var response = await client.GetAsync(request);
            var rate = JsonConvert.DeserializeObject<ExchangeRate>(response.Content);

            return rate;
        }
    }
}
