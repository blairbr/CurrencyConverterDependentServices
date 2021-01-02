using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using stripe_api_dependentservices.Entities;

namespace stripe_api_dependentservices.Services
{
    public interface ICurrencyExchangeService
    {
        //stubbed out methods like GetAllCurrencies.
        //anything that's async needs to return a Task, right?
        Task<Currency> GetAllCurrenciesAsync();
    }
}
