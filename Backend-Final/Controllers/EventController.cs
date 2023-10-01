using Microsoft.AspNetCore.Mvc;

namespace Backend_Final.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
