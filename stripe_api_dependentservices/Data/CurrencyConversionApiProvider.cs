using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using stripe_api_dependentservices.Entities;

namespace stripe_api_dependentservices.Data
{
    public class CurrencyConversionApiProvider : ICurrencyConversionApiProvider
    {
        private static readonly string _requestURL = "https://v6.exchangerate-api.com/v6/26a38035021b57938540e572/latest/USD";
        public async Task<ConversionRates> GetConversionRatesAsync()
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _requestURL);
            HttpResponseMessage response = await client.SendAsync(request);
            string responseAsString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ConversionRates>(responseAsString);
        }
    }
}
