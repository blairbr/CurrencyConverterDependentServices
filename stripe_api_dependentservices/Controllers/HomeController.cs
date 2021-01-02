using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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


        // make this async and explain why
        public async Task<IActionResult> Index()
        {
            //controller -> service -> api provider type class
            var currencies = await _apiService.GetAllCurrenciesAsync();
            return View();
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
