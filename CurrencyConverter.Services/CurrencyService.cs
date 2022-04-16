using CurrencyConverter.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using RestSharp;

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
            RestResponse response = new RestResponse();
            response = await client.ExecuteGetAsync(request);
            if (response.StatusCode is not System.Net.HttpStatusCode.OK)
                throw new Exception(JObject.Parse(response.Content)["error"]?.ToString());

            var rate = JsonConvert.DeserializeObject<ExchangeRate>(response.Content);
            return rate;

        }
    }
}
