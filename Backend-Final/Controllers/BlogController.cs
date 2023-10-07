using Backend_Final.DAL;
using Backend_Final.ViewModels;
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
                .Include(b => b.Category)
                .FirstOrDefault(b=>b.Id == id);
            return View(blog);
        }
        public IActionResult Search(string? search)
        {
            var blogs = _context.Blog
                    .Where(p => p.Title.ToLower().Contains(search.ToLower()))
                    .OrderBy(p => p.Id)
                    .Take(5)
                    .ToList();

            return PartialView("_Search", new SearchVM(blogs,null,null));
        }
      
    }
}
