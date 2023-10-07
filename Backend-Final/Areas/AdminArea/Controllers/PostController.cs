using Microsoft.AspNetCore.Mvc;

namespace Backend_Final.Areas.AdminArea.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
