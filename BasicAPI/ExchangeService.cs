using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices.JavaScript;

namespace BasicAPI
{
    public class ExchangeService
    {

        private readonly HttpClient _httpClient;

        public ExchangeService(HttpClient httpClient)
        {

            _httpClient = httpClient;

        }

        public async Task<JObject>GetExchangeServiceAsync()
        {

            var response = await _httpClient.GetStringAsync("https://latest.currency-api.pages.dev/v1/currencies/eur.json");
            return JObject.Parse(response);

        }


    }
}
