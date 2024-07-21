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
        private readonly ILogger<ExchangeRateController> _logger;


        public ExchangeRateController(ExchangeService exchangeService,ILogger<ExchangeRateController>logger)
        {
            _exchangeService = exchangeService;
            _logger = logger;

        }

        [HttpGet]
        public  async Task<IActionResult> GetPost()
        {

            var post = await _exchangeService.GetPost();
            return Ok(post);
            _logger.LogInformation("Get İşlemi Başarıyla Sağlandı");
        }

        [HttpPost]
        public async Task<IActionResult> SavePost()
        {
            try
            {
                await _exchangeService.SavePost();
                _logger.LogInformation("Get İşlemi Başarıyla Sağlandı");
            }
            catch (Exception ex)
            {

                _logger.LogError("Hata bilmiorum", ex);
            }
            return Ok(new { Message = "Kayıt Başarılı" });

        }
    }
}
