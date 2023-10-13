using Backend_Final.DAL;
using Backend_Final.Extensions;
using Backend_Final.Models;
using Backend_Final.Models.Emails;
using Backend_Final.Services;
using Backend_Final.ViewModels.AdminBlog;
using Backend_Final.ViewModels.AdminEvent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;

namespace Backend_Final.Areas.AdminArea.Controllers
{
    [Area(nameof(AdminArea))]
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly EmailConfig _emailServices;

        public BlogController(AppDbContext context, IWebHostEnvironment webHostEnvironment, EmailConfig emailServices)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _emailServices = emailServices;
        }

        public IActionResult Index()
        {
            var blogs =_context.Blog
                .Include(b=>b.Category)
                .ToList();
            return View(blogs);
        }

        //-----------Create-----------

        public IActionResult Create() {
            ViewBag.Categories=_context.Category.ToList();
        return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(CreateBlogVM createBlogVM,int id)
        {
            //-----------------------------------------
            //-----------------------------------------
            //-----------------------------------------
            var userEmails = _context.Subscribers.ToList();
            List<string> emails = new List<string>();
            foreach (var userEmail in userEmails)
            {
                emails.Add(userEmail.Email);

            }
            EmailServices es = new(_emailServices);
            MimeMessage mimeMessage = new();

            var message = es.CreateEmail(
            createBlogVM.Title,
           @$"There is created new Blog in EduHome.The blog's name is {createBlogVM.Title}.
            Blog's Author name is {createBlogVM.Author}.
           Thank you for attention. ",
             emails);
            es.SendEmail(message);
            //-----------------------------------------
            //-----------------------------------------
            //-----------------------------------------
            if (!ModelState.IsValid) return View();
            Blog blog = new();
            blog.Title = createBlogVM.Title;
            blog.Author = createBlogVM.Author;
            blog.Date=createBlogVM.Date;
            blog.Description = createBlogVM.Desc;
            blog.CategoryId = id;
            if(!createBlogVM.Image.CheckImage()) {
                ModelState.AddModelError("image", "Yalniz shekil!!!");
                return View();
            }
            if(createBlogVM.Image.CheckSize(1000))
            {
                ModelState.AddModelError("image", "Sheklin olcusu cox boyukdur!!!");
                return View();

            }
            blog.ImgUrl = createBlogVM.Image.SaveImage("img/blog", _webHostEnvironment);
            _context.Blog.Add(blog);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Update(int? id)
        {
            var blog = _context.Blog.FirstOrDefault(e => e.Id == id);
            UpdateBlogVM vm = new();
            vm.Title = blog.Title;
            vm.Desc = blog.Description;
            vm.Date = blog.Date;
            vm.Author = blog.Author;

            ViewBag.Categories = _context.Category.ToList();
            ViewBag.Blog = _context.Blog.FirstOrDefault(b => b.Id == id);
            return View(vm);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(UpdateBlogVM blogUpdateVM, int id, int categoryId)
        {
            var blog = _context.Blog.FirstOrDefault(e => e.Id == id);
            ViewBag.Categories = _context.Category.ToList();
            ViewBag.Blog = _context.Blog.FirstOrDefault(b=>b.Id== id);
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "required!");
                return View();
            }
            if (_context.Event.Any(s => s.Title == blogUpdateVM.Title))
            {
                ModelState.AddModelError("Title", "Bu adli evnet artiq var!");
                return View();
            }
            blog.Title = blogUpdateVM.Title;
            blog.Description = blogUpdateVM.Desc;
            blog.Date = blogUpdateVM.Date;
            blog.Author = blogUpdateVM.Author;
            blog.CategoryId = categoryId;
            if (blogUpdateVM.Image.CheckSize(10000))
            {
                ModelState.AddModelError("Image", "Sheklin olcusu cox boyukdur!");
                return View();
            }
            if (!blogUpdateVM.Image.CheckImage())
            {
                ModelState.AddModelError("Image", "Yalniz shekil!");
                return View();
            }
            blog.ImgUrl = blogUpdateVM.Image.SaveImage("img/blog", _webHostEnvironment);
            _context.SaveChanges();
           
            return RedirectToAction("index");
        }

        public IActionResult Delete(int?id)
        {
            if (id == null) return NotFound();
            var blog = _context.Blog.FirstOrDefault(b=>b.Id==id);
            if (blog == null) return NotFound();
            _context.Blog.Remove(blog);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
