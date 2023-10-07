using Backend_Final.DAL;
using Backend_Final.Models;
using Backend_Final.ViewModels.AdminTag;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Final.Areas.AdminArea.Controllers
{
    [Area(nameof(AdminArea))]
    public class TagController : Controller
    {
        private readonly AppDbContext _context;
        public TagController(AppDbContext appDbContext)
        {
            _context=appDbContext;
        }
        public IActionResult Index()
        {
            var tags = _context.Tag.ToList();
            return View(tags);
        }
        //----------Create-------------

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(CreateTagVM createTagVM)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            if (_context.Tag.Any(t => t.Name == createTagVM.Name)) {
                ModelState.AddModelError("Name", "Eyni adli tag-ler yaratmaq olmaz!!!");
                return View();
            }

            Tag tag = new();
            tag.Name = createTagVM.Name;
            _context.Tag.Add(tag);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        //----------Update-------------

        public IActionResult Update(int?id)
        {

            UpdateTagVM updateTagVM = new();
            var tag= _context.Tag.FirstOrDefault(t => t.Id == id);
            updateTagVM.Name = tag.Name;

            return View(updateTagVM);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(int?id,UpdateTagVM updateTagVM)
        {

            if (_context.Tag.Any(t => t.Name == updateTagVM.Name))
            {
                ModelState.AddModelError("Name", "Eyni adli tag artiq movcuddur!!!");
                return View();
            }
            if (!ModelState.IsValid) return BadRequest();
            var tag= _context.Tag.FirstOrDefault(t => t.Id == id);
            tag.Name=updateTagVM.Name;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        //----------Delete-------------
        public IActionResult Delete(int?id)
        {
            if(id==null) return BadRequest();
            var tag = _context.Tag.FirstOrDefault(t=>t.Id==id);
            _context.Tag.Remove(tag);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        //----------Detail-------------

        public IActionResult Detail(int?id)
        {
            if (id == null) return BadRequest();
            var tag= _context.Tag.FirstOrDefault(t=>t.Id==id);
            if (tag == null) return NotFound();
            return View(tag);

        }
    }
}
