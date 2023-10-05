using Backend_Final.DAL;
using Backend_Final.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_Final.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;

        public AboutController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            AboutVM vm = new AboutVM();
            vm.About = _context.About.FirstOrDefault();
            vm.Testimonial=_context.Testimonial.ToList();
            vm.Teacher=_context.Teacher.Include(t=>t.TeacherSocialMedia).ToList();
            vm.Event=_context.Event.ToList();
            return View(vm);
        }
    }
}
