using Backend_Final.DAL;
using Backend_Final.Extensions;
using Backend_Final.Models;
using Backend_Final.ViewModels.AdminPost;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Final.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class PostController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webEnvironment;

        public PostController(AppDbContext context, IWebHostEnvironment webEnvironment)
        {
            _context = context;
            _webEnvironment = webEnvironment;
        }

        public IActionResult Index()
        {
            var posts=_context.Post.ToList();
            return View(posts);
        }
        //Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(CreatePostVM createPostVM)
        {
            if(!ModelState.IsValid)
            {
                return View();
;            }
            Post post = new();
            post.Title = createPostVM.Title;
            post.Date = createPostVM.Date;
            post.Author = createPostVM.Author;
            if (!createPostVM.Image.CheckImage())
            {
                ModelState.AddModelError("image", "Yalniz shekil!!!");
                return View();
            }
            if (createPostVM.Image.CheckSize(1000))
            {
                ModelState.AddModelError("image", "Sheklin olcusu cox boyuktur");
                return View();
            }
            post.ImgUrl = createPostVM.Image.SaveImage("img/post", _webEnvironment)[0];
            _context.Post.Add(post);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        //Delete
        public IActionResult Delete(int?id)
        {
            if (id == null) return NotFound();
            var post = _context.Post.FirstOrDefault(x => x.Id == id);
            if (post == null) return NotFound();
            _context.Post.Remove(post);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        //Update
        public IActionResult Update(int?id)
        {
            UpdatePostVM vm = new();
            var post=_context.Post.FirstOrDefault(y => y.Id == id);    
            vm.Title = post.Title;
            vm.Author = post.Author;
            vm.Date = post.Date;
            return View(vm);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(int?id,UpdatePostVM updatePostVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
                ;
            }
            var post = _context.Post.FirstOrDefault(y => y.Id == id);
            post.Title = updatePostVM.Title;
            post.Date = updatePostVM.Date;
            post.Author = updatePostVM.Author;
            if (!updatePostVM.Image.CheckImage())
            {
                ModelState.AddModelError("image", "Yalniz shekil!!!");
                return View();
            }
            if (updatePostVM.Image.CheckSize(1000))
            {
                ModelState.AddModelError("image", "Sheklin olcusu cox boyuktur");
                return View();
            }
            post.ImgUrl = updatePostVM.Image.SaveImage("img/post", _webEnvironment)[0];
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Detail(int?id)
        {
            if(id == null)
            {
                return View();
            }
            var posts = _context.Post.FirstOrDefault(p=>p.Id==id);
            if(posts == null) { return NotFound(); }
            return View(posts);
        }
    }
}
