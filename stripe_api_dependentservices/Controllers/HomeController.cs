﻿using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using stripe_api_dependentservices.Models;
using stripe_api_dependentservices.Services;

namespace stripe_api_dependentservices.Controllers
{
    public class HomeController : Controller
    {
        //properties
        private readonly ILogger<HomeController> _logger;
        private readonly ICurrencyExchangeService _apiService;

        public HomeController(ILogger<HomeController> logger, ICurrencyExchangeService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var currencies = await _apiService.GetAllCurrenciesAsync();
            return View(currencies);
        }

        [HttpPost]
        public ActionResult Submit(CurrencyModel formData) 
        {
            //formData.ConversionRate = _apiService.FindConversionRate(formData.TargetCurrencyCode); //if i do something like this, I'm making a second call to the API. There has to be a better way. I think my setup isn't good
            CurrencyModel formDataModelWithFinalAmount = _apiService.CalculateValueInTargetCurrency(formData);
            CurrencyModel formDataFinal = _apiService.PopulateModel(formDataModelWithFinalAmount);
            return PartialView("~/Views/Shared/_totalInTargetCurrencyMessage.cshtml", formDataFinal);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
