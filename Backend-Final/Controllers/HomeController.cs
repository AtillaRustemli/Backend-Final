using Microsoft.AspNetCore.Mvc;

namespace Backend_Final.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
