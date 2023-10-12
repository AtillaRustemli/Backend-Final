using Backend_Final.DAL;
using Backend_Final.Models.Emails;
using Backend_Final.Services;
using Backend_Final.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_Final.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IEmailServices _emailServices;

        public HomeController(AppDbContext context,IEmailServices emailServices)
        {
            _context = context;
            _emailServices = emailServices;
        }

        public async Task<IActionResult> Index()
        {
            UserEmailOptions options = new()
            {
                ToEmails=new List<string> { "rustemliatilla662@gmail.com" }
            };
            await _emailServices.SendTestEmail(options);

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
