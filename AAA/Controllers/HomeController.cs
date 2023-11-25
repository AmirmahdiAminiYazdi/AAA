using Microsoft.AspNetCore.Mvc;

namespace AAA.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
