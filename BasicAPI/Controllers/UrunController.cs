using Microsoft.AspNetCore.Mvc;

namespace BasicAPI.Controllers
{
    public class UrunController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
