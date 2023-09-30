using Backend_Final.DAL;
using Backend_Final.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Final.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeVM vm = new();
            vm.Slider=_context.Slider.ToList();
            return View(vm);
        }
    }
}
