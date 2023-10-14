using Backend_Final.DAL;
using Backend_Final.Models;
using Backend_Final.ViewModels.AdminTeacher;
using Backend_Final.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_Final.Areas.AdminArea.Controllers
{
    [Area(nameof(AdminArea))]
    public class TeacherController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TeacherController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var teacher = _context.Teacher.ToList();

            return View(teacher);
        }
        //--------------Create-----------
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(CreateTeacherVM createTeacherVM)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Salam");
                return View();
            }
            Teacher teacher = new();
            teacher.Name = createTeacherVM.Name;
            teacher.Specilty=createTeacherVM.Specilty;
            teacher.AboutMe = createTeacherVM.AboutMe;
            teacher.Description = createTeacherVM.Desc;
           
            if (!createTeacherVM.Image.CheckImage())
            {
                ModelState.AddModelError("Image", "Yalniz Shekil!!!");
                return View();
            }
            if (createTeacherVM.Image.CheckSize(1000))
            {
                ModelState.AddModelError("Image", "Sheklin olcusu cox boyukdur!!!");
                return View();
            }
            teacher.ImgUrl = createTeacherVM.Image.SaveImage("img/teacher", _webHostEnvironment);
            _context.Teacher.Add(teacher);
            _context.SaveChanges();


            TeacherContactInfo contactInfo = new()
            {
            Email=createTeacherVM.TeacherContactInfo.Email,
            Number=createTeacherVM.TeacherContactInfo.Number,
            Skype=createTeacherVM.TeacherContactInfo.Skype,
            TeacherId = teacher.Id,

            };
            _context.TeacherContactInfo.Add(contactInfo);
            _context.SaveChanges();

            TeacherSkill teacherSkill = new()
            {
                Language=createTeacherVM.TeacherSkill.Language,
                TeamLeader=createTeacherVM.TeacherSkill.TeamLeader,
                Innovation=createTeacherVM.TeacherSkill.Innovation,
                Communication=createTeacherVM.TeacherSkill.Communication,
                Design=createTeacherVM.TeacherSkill.Design,
                Development=createTeacherVM.TeacherSkill.Development,
                TeacherId=teacher.Id,

            };
            _context.TeacherSkill.Add(teacherSkill);
            _context.SaveChanges();

            TeacherSocialMedia socialMedia = new()
            {
            Facebook=createTeacherVM.TeacherSocialMedia.Facebook,
            Pinterest=createTeacherVM.TeacherSocialMedia.Pinterest,
            Vimeo=createTeacherVM.TeacherSocialMedia.Vimeo,
            Twitter=createTeacherVM.TeacherSocialMedia.Twitter,
            TeacherId = teacher.Id,
            };
            _context.TeacherSocialMedia.Add(socialMedia);
            _context.SaveChanges();

            TeacherPersonInfo personInfo = new()
            {
            Degree=createTeacherVM.TeacherPersonInfo.Degree,
            Experience=createTeacherVM.TeacherPersonInfo.Experience,
            Hobbies=createTeacherVM.TeacherPersonInfo.Hobbies,
            Faculty=createTeacherVM.TeacherPersonInfo.Faculty,
            TeacherId = teacher.Id,

            };
            _context.TeacherPersonInfo.Add(personInfo);

          
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        //----------------Update-------------
        public IActionResult Update(int?Id)
        {
            UpdateTeacherVM updateTeacherVM = new();
            var teacher=_context.Teacher
                .Include(t=>t.TeacherSocialMedia)
                .Include(t=>t.TeacherPersonInfo)
                .Include(t=>t.TeacherContactInfo)
                .Include(t=>t.TeacherSkill)
                .FirstOrDefault(x => x.Id == Id);
            updateTeacherVM.Name = teacher.Name;
            updateTeacherVM.Desc = teacher.Description;
            updateTeacherVM.Specilty = teacher.Specilty;
            updateTeacherVM.AboutMe = teacher.AboutMe;
            updateTeacherVM.TeacherSocialMedia= teacher.TeacherSocialMedia;
            updateTeacherVM.TeacherSkill= teacher.TeacherSkill;
            updateTeacherVM.TeacherContactInfo= teacher.TeacherContactInfo;
            updateTeacherVM.TeacherPersonInfo= teacher.TeacherPersonInfo;
            return View(updateTeacherVM);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(UpdateTeacherVM? createTeacherVM, int? id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var teacher = _context.Teacher.FirstOrDefault(t=>t.Id==id);
            teacher.Name = createTeacherVM.Name;
            teacher.Specilty = createTeacherVM.Specilty;
            teacher.AboutMe = createTeacherVM.AboutMe;
            teacher.Description = createTeacherVM.Desc;
            if (!createTeacherVM.Image.CheckImage())
            {
                ModelState.AddModelError("Image", "Yalniz Shekil!!!");
                return View();
            }
            if (createTeacherVM.Image.CheckSize(1000))
            {
                ModelState.AddModelError("Image", "Sheklin olcusu cox boyukdur!!!");
                return View();
            }
            teacher.ImgUrl = createTeacherVM.Image.SaveImage("img/teacher", _webHostEnvironment);
            _context.SaveChanges();

            TeacherContactInfo contactInfo = _context.TeacherContactInfo.FirstOrDefault(t => t.TeacherId == id);
            contactInfo.Email = createTeacherVM.TeacherContactInfo.Email;
            contactInfo.Number = createTeacherVM.TeacherContactInfo.Number;
            contactInfo.Skype = createTeacherVM.TeacherContactInfo.Skype;

            _context.SaveChanges();

            var teacherSkill = _context.TeacherSkill.FirstOrDefault(t => t.TeacherId == id);
            
                teacherSkill.Language = createTeacherVM.TeacherSkill.Language;
                teacherSkill.TeamLeader = createTeacherVM.TeacherSkill.TeamLeader;
                teacherSkill.Innovation = createTeacherVM.TeacherSkill.Innovation;
                teacherSkill.Communication = createTeacherVM.TeacherSkill.Communication;
                teacherSkill.Design = createTeacherVM.TeacherSkill.Design;
                teacherSkill.Development = createTeacherVM.TeacherSkill.Development;

                ;
            _context.SaveChanges();

            var socialMedia = _context.TeacherSocialMedia.FirstOrDefault(t => t.TeacherId == id);            
                socialMedia.Facebook = createTeacherVM.TeacherSocialMedia.Facebook;
                socialMedia.Pinterest = createTeacherVM.TeacherSocialMedia.Pinterest;
                socialMedia.Vimeo = createTeacherVM.TeacherSocialMedia.Vimeo;
                socialMedia.Twitter = createTeacherVM.TeacherSocialMedia.Twitter;
            
            _context.SaveChanges();

            var personInfo = _context.TeacherPersonInfo.FirstOrDefault(t => t.TeacherId == id);
            {
                personInfo.Degree = createTeacherVM.TeacherPersonInfo.Degree;
                personInfo.Experience = createTeacherVM.TeacherPersonInfo.Experience;
                personInfo.Hobbies = createTeacherVM.TeacherPersonInfo.Hobbies;
                personInfo.Faculty = createTeacherVM.TeacherPersonInfo.Faculty;

            };
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        //----------------Remove-------------------
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var teacher=_context.Teacher.FirstOrDefault(t=>t.Id==id);
            var teacherSocialMedia=_context.TeacherSocialMedia.FirstOrDefault(t=>t.TeacherId==id);
            var teacherPersonInfo=_context.TeacherPersonInfo.FirstOrDefault(t=>t.TeacherId==id);
            var teacherContactInfo=_context.TeacherContactInfo.FirstOrDefault(t=>t.TeacherId==id);
            var teacherSkill=_context.TeacherSkill.FirstOrDefault(t=>t.TeacherId==id);
            if (teacher == null) return NotFound();
            _context.Teacher.Remove(teacher);
            _context.TeacherSocialMedia.Remove(teacherSocialMedia);
            _context.TeacherPersonInfo.Remove(teacherPersonInfo);
            _context.TeacherSkill.Remove(teacherSkill);
            _context.TeacherContactInfo.Remove(teacherContactInfo);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
