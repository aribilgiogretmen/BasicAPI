using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace BasicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeRateController : Controller
    {

        private readonly ExchangeService _exchangeService;

        public ExchangeRateController(ExchangeService exchangeService)
        {
            _exchangeService = exchangeService;

        }

        [HttpGet]
        public  async Task<IActionResult> GetExchangeRates()
        {

            JObject exchangeRate = await _exchangeService.GetExchangeServiceAsync();
            return Ok(exchangeRate);
        }
    }
}
