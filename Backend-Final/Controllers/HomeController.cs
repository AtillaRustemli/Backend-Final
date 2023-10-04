using Backend_Final.DAL;
using Backend_Final.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            vm.Slider=_context.Slider.Include(si=>si.SliderImgae).ToList();
            vm.Blog=_context.Blog.ToList();
            vm.Course=_context.Course.ToList();
            vm.Event=_context.Event.ToList();
            vm.Testimonial=_context.Testimonial.ToList();
            vm.NoticeAreaRight=_context.NoticeAreaRight.ToList();
            vm.WhyChooseUs=_context.WhyChooseUs.FirstOrDefault();
            return View(vm);
        }
    }
}
