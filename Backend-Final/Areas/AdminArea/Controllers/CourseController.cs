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
        public IActionResult Create(CreateCourseVM createCourseVM,int id)
        {
            ViewBag.Categories = _context.Category.ToList();
            if (!ModelState.IsValid)
            {
                return View();
            }
            Course course = new();
            course.CategoryId = id;
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
    }
}
