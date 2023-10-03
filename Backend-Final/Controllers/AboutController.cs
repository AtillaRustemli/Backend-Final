using Microsoft.AspNetCore.Mvc;

namespace Backend_Final.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
