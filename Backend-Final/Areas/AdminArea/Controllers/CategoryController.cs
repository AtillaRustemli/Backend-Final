using Backend_Final.DAL;
using Backend_Final.Models;
using Backend_Final.ViewModels.AdminCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_Final.Areas.AdminArea.Controllers
{
    [Area(nameof(AdminArea))]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Category.ToList();
            return View(categories);
        }

        //Delete
        public IActionResult Delete(int?id)
        {
            if (id == null) return NotFound();
            var category= _context.Category.FirstOrDefault(c => c.Id==id);
            if (category==null) return NotFound();
            var categoryToDelete = _context.Category.Find(id);

            // Find all events referencing this category
            var eventsToUpdate = _context.Event.Where(e => e.CategoryId == id);

            foreach (var @event in eventsToUpdate)
            {
                
                @event.CategoryId = null; 
            }
            _context.Category.Remove(category);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        //Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(CreateCategoryVM createCategory)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            Category category = new();
            category.Name = createCategory.Name;
            _context.Category.Add(category);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        //-----------------Update-------------------
        public IActionResult Update(int?id)
        {
            if(id == null) return NotFound();
            var category = _context.Category.FirstOrDefault(e => e.Id==id);
            if (category==null) return NotFound();
            UpdateCategoryVM updateCategory = new();
            updateCategory.Name = category.Name;
            return View(updateCategory);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(int?id,UpdateCategoryVM updateCategory)
        {
            if(id == null) return NotFound();
            if(!ModelState.IsValid)
            {
                return View();
            }
            var category = _context.Category.FirstOrDefault(e => e.Id == id);
            category.Name=updateCategory.Name;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Detail(int?id)
        {
            if(id == null) return NotFound();
            var category = _context.Category.FirstOrDefault(c=>c.Id==id);
            if(category==null) return NotFound();

            return View(category);
        }

    }
   
    
}
