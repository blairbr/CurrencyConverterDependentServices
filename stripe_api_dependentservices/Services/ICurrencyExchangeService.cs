﻿using System.Threading.Tasks;
using stripe_api_dependentservices.Entities;
using stripe_api_dependentservices.Models;

namespace stripe_api_dependentservices.Services
{
    public interface ICurrencyExchangeService
    {
        //stubbed out methods like GetAllCurrencies.
        //anything that's async needs to return a Task, right?
        Task<ConversionRates> GetAllCurrenciesAsync();

        CurrencyModel PopulateModel(CurrencyModel formDataModel);
        CurrencyModel CalculateValueInTargetCurrency(CurrencyModel formDataModel);
    }
}
