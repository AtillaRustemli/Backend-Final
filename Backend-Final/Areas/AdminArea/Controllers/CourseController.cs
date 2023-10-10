using Backend_Final.DAL;
using Backend_Final.Extensions;
using Backend_Final.Models;
using Backend_Final.ViewModels.AdminCategory;
using Backend_Final.ViewModels.AdminCourse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Backend_Final.Areas.AdminArea.Controllers
{
    [Area(nameof(AdminArea))]
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHost;

        public CourseController(AppDbContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }

        public IActionResult Index()
        {
            var couses=_context.Course
                .Include(c=>c.Category)
                .ToList();
            return View(couses);
        }
        //Delete
        public IActionResult Delete(int?id)
        {
            if (id == null) return BadRequest();
            var courses=_context.Course.First(c => c.Id == id);
            if (courses == null) return BadRequest();
            _context.Course.Remove(courses);
            _context.SaveChanges();
            foreach(var courseDetail in courses.CourseDetail)
            {
                _context.CourseDetail.Remove(courseDetail);
                _context.SaveChanges();
            }
            var courseFeature=_context.CourseFeature.FirstOrDefault(cf=>cf.CourseId==id);
            _context.CourseFeature.Remove(courseFeature);

            _context.SaveChanges();
            return View();
        }
        //Create
        public IActionResult Create()
        {
            ViewBag.Categories=_context.Category.ToList();
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(CreateCourseVM createCourseVM,int categoryId)
        {
            ViewBag.Categories = _context.Category.ToList();
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (_context.Course.Any(c=>c.Name== createCourseVM.Name))
            {
                ModelState.AddModelError("Name", "Bu adli Kurs artiq movcuddur");
                return View();
            }
            Course course = new();
            course.CategoryId = categoryId;
            course.Name = createCourseVM.Name;
            course.Description = createCourseVM.Desc;
            if (!createCourseVM.Image.CheckImage())
            {
                ModelState.AddModelError("image", "Yalniz shekil");
                return View();
            }
            if (createCourseVM.Image.CheckSize(1000))
            {
                ModelState.AddModelError("image", "Sheklin olcusu cox boyukdur!!!");
                return View();
            }
            course.ImgUrl = createCourseVM.Image.SaveImage("img/course", _webHost);
            _context.Course.Add(course);
            _context.SaveChanges();
           
            CourseDetail newCourseDetail = new();
            newCourseDetail.Description = createCourseVM.CourseDetail.Description;
            newCourseDetail.Title = createCourseVM.CourseDetail.Title;
            newCourseDetail.CourseId=course.Id;
            _context.CourseDetail.Add(newCourseDetail);
            _context.SaveChanges();

            
            CourseFeature courseFeature = new()
            {
            Language = createCourseVM.CourseFeature.Language,
            SkillLevel = createCourseVM.CourseFeature.SkillLevel,
            Starts = createCourseVM.CourseFeature.Starts,
            Students = createCourseVM.CourseFeature.Students,
            ClassDuration = createCourseVM.CourseFeature.Language,
            Fee = createCourseVM.CourseFeature.Fee,
            Assesment = createCourseVM.CourseFeature.Assesment,
            Duration = createCourseVM.CourseFeature.Duration,
            CourseId = course.Id,

            };
            _context.CourseFeature.Add(courseFeature);
            _context.SaveChanges();
            return RedirectToAction("index");
        }


        public IActionResult Update(int?id)
        {
            ViewBag.Categories = _context.Category.ToList();
            UpdateCourseVM updateCourseVM = new();
            ViewBag.Course = _context.Course.FirstOrDefault(c=>c.Id==id).CategoryId;
            var course=_context.Course
                .Include(c=>c.CourseDetail)
                .Include(c=>c.CourseFeature)
                .FirstOrDefault(c=>c.Id==id);
            updateCourseVM.CourseFeature = course.CourseFeature;
            updateCourseVM.Name = course.Name;
            updateCourseVM.Desc = course.Description;
            updateCourseVM.CourseDetail=course.CourseDetail.FirstOrDefault();
            return View(updateCourseVM);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(UpdateCourseVM updateCourseVM, int categoryId, int? id)
        {
            ViewBag.Course = _context.Course.FirstOrDefault(c => c.Id == id).CategoryId;
            ViewBag.Categories = _context.Category.ToList();
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (_context.Course.Any(c => c.Name == updateCourseVM.Name))
            {
                ModelState.AddModelError("Name", "Bu adli Kurs artiq movcuddur");
                return View();
            }
            var course = _context.Course.FirstOrDefault(c=>c.Id==id);
            course.CategoryId = categoryId;
            course.Name = updateCourseVM.Name;
            course.Description = updateCourseVM.Desc;
            if (!updateCourseVM.Image.CheckImage())
            {
                ModelState.AddModelError("image", "Yalniz shekil");
                return View();
            }
            if (updateCourseVM.Image.CheckSize(1000))
            {
                ModelState.AddModelError("image", "Sheklin olcusu cox boyukdur!!!");
                return View();
            }
            course.ImgUrl = updateCourseVM.Image.SaveImage("img/course", _webHost);
            _context.SaveChanges();

            var newCourseDetail = _context.CourseDetail.FirstOrDefault(cd=>cd.CourseId==id);
            newCourseDetail.Description = updateCourseVM.CourseDetail.Description;
            newCourseDetail.Title = updateCourseVM.CourseDetail.Title;
            newCourseDetail.CourseId = course.Id;
            _context.SaveChanges();


            var newCourseFeatur = _context.CourseFeature.FirstOrDefault(cd => cd.CourseId == id);
            newCourseFeatur.Language = updateCourseVM.CourseFeature.Language;
            newCourseFeatur.SkillLevel = updateCourseVM.CourseFeature.SkillLevel;
            newCourseFeatur.Starts = updateCourseVM.CourseFeature.Starts;
            newCourseFeatur.Students = updateCourseVM.CourseFeature.Students;
            newCourseFeatur.ClassDuration = updateCourseVM.CourseFeature.ClassDuration;
            newCourseFeatur.Fee = updateCourseVM.CourseFeature.Fee;
            newCourseFeatur.Assesment = updateCourseVM.CourseFeature.Assesment;
            newCourseFeatur.Duration = updateCourseVM.CourseFeature.Duration;
            newCourseFeatur.CourseId = course.Id;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
