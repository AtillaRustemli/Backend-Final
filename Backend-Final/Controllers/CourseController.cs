using Backend_Final.DAL;
using Backend_Final.Models;
using Backend_Final.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_Final.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;

        public CourseController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string search)
        {
            var course= search == null ? _context.Course.ToList() : _context.Course.ToList().Where(c => c.Name.ToLower().Contains(search.ToLower())).ToList();
            return View(course);
        }
        public IActionResult Detail(int?id)
        {
            ViewBag.Categories = _context.Category.ToList();
            ViewBag.Course = _context.Course.ToList();
            ViewBag.Tags = _context.Tag.ToList();
            ViewBag.Posts = _context.Post.ToList();
            ViewBag.CourseDetaiIImage = _context.CourseDetaiIImage.FirstOrDefault().ImgUrl;
            var course=_context.Course
                .Include(c=>c.CourseDetail)
                .Include(c=>c.CourseFeature)
                .Include(c=>c.Category)
                .FirstOrDefault(c=>c.Id==id);
            return View(course);
        }
        public IActionResult Search(string? search)
        {
            var course = _context.Course
                    .Where(p => p.Name.ToLower().Contains(search.ToLower()))
                    .OrderBy(p => p.Id)
                    .Take(5)
                    .ToList();

            return PartialView("_Search", new SearchVM(null, null, course));
        }

    }
}
