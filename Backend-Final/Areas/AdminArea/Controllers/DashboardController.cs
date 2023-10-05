using Microsoft.AspNetCore.Mvc;

namespace Backend_Final.Areas.AdminArea.Controllers
{
    [Area(nameof(AdminArea))]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
