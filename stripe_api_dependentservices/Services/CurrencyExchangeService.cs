﻿using System.Threading.Tasks;
using stripe_api_dependentservices.Entities;
using stripe_api_dependentservices.Data;
using stripe_api_dependentservices.Models;

namespace stripe_api_dependentservices.Services
{
    public class CurrencyExchangeService : ICurrencyExchangeService

    {
        public readonly ICurrencyConversionApiProvider _apiProvider;
        public CurrencyExchangeService(ICurrencyConversionApiProvider apiProvider)
        {
            _apiProvider = apiProvider;
        }

        public async Task<ConversionRates> GetAllCurrenciesAsync() {
            var currencies = await _apiProvider.GetConversionRatesAsync();
            return currencies;
        }

        public CurrencyModel CalculateValueInTargetCurrency(CurrencyModel formDataModel)
        {
            formDataModel.FinalAmountInTargetCurrency = formDataModel.AmountToBeConverted * formDataModel.ConversionRate;
            return formDataModel;
        }

        public CurrencyModel PopulateModel(CurrencyModel formDataModel)
        {
            CurrencyModel newFormDataModel = new CurrencyModel()
            {
                //only need these two properties... perhaps could return a string of them mashed together instead...
                FinalAmountInTargetCurrency = formDataModel.FinalAmountInTargetCurrency,
                TargetCurrencyCode = formDataModel.TargetCurrencyCode
            };
            return newFormDataModel;
        }

    }
}
