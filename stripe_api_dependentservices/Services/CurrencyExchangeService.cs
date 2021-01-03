using System.Threading.Tasks;
using stripe_api_dependentservices.Entities;
using stripe_api_dependentservices.Data;

namespace stripe_api_dependentservices.Services
{
    public class CurrencyExchangeService : ICurrencyExchangeService

    {
        public readonly ICurrencyConversionApiProvider _apiProvider;
        public CurrencyExchangeService(ICurrencyConversionApiProvider apiProvider)
        {
            _apiProvider = apiProvider;
        }

        //make a async method that returns a Task<List<Currency>> that gets all currencies
        public async Task<Currency> GetAllCurrenciesAsync() {
            var currencies = await _apiProvider.GetCurrenciesAsync();
            return currencies;
        }
    }
}
