using System.Threading.Tasks;
using stripe_api_dependentservices.Entities;

namespace stripe_api_dependentservices.Data
{
    public interface ICurrencyConversionApiProvider
    {
        public Task<Currency> GetCurrenciesAsync();
    }
}
