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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public async Task<ExchangeRate> HistoricalExchangeRate(DateTime date, string from, string key)
        {

            var client = new RestClient($"https://api.fastforex.io/historical?api_key={key}");
            var request = new RestRequest();
            request.AddHeader("Accept", "application/json");
            request.AddParameter("date", date.ToString("yyyy-MM-dd"));
            request.AddParameter("from", from);
            var response = await client.GetAsync(request);
            ExchangeRate rate = new ExchangeRate();
            var dynamic = JsonConvert.DeserializeObject<dynamic>(response.Content);

            rate.date = dynamic.date;
            rate.ms = dynamic.ms;
            rate.@base = dynamic.@base;
            rate.results = JsonConvert.DeserializeObject<Results>(dynamic.results);

            return rate;
        }
    }
}
