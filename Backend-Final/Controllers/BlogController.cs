using Backend_Final.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_Final.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var blog = _context.Blog.ToList();
            return View(blog);
        }
        public IActionResult Detail(int? id)
        {
            ViewBag.Categories=_context.Category.ToList();
            ViewBag.Blogs=_context.Blog.ToList();
            ViewBag.Tags=_context.Tag.ToList();
            ViewBag.Posts=_context.Post.ToList();
           var blog = _context.Blog
                .Include(b => b.Tag)
                .Include(b => b.Category)
                .Include(b => b.Post)
                .FirstOrDefault(b=>b.Id == id);
            return View(blog);
        }
    }
}
