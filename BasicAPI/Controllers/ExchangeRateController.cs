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
        public  async Task<IActionResult> GetPost()
        {

            var post = await _exchangeService.GetPost();
            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> SavePost()
        {

            await _exchangeService.SavePost();
            return Ok(new {Message="Kayıt Başarılı"});
        }
    }
}
