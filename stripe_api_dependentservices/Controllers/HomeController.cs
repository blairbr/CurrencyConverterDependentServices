using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using stripe_api_dependentservices.Models;
using stripe_api_dependentservices.Services;

namespace stripe_api_dependentservices.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICurrencyExchangeService _apiService;

        public HomeController(ICurrencyExchangeService apiService)
        {
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
            var codeAndRate = formData.CodeAndRate.Split(" - ");
            formData.TargetCurrencyCode = codeAndRate[0];
            formData.ConversionRate = decimal.Parse(codeAndRate[1]);

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
