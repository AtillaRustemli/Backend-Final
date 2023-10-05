using Backend_Final.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_Final.Controllers
{
    public class TeacherController : Controller
    {
        private readonly AppDbContext   _context;

        public TeacherController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            var teacher=_context.Teacher
                .Include(t=>t.TeacherSocialMedia)
                .Include(t=>t.TeacherContactInfo)
                .Include(t=>t.TeacherPersonInfo)
                .Include(t=>t.TeacherSkill)
                .ToList() ;
            return View(teacher);
        }
        public IActionResult Detail(int?id)
        {
            var teacher= _context.Teacher
                .Include(t=> t.TeacherSocialMedia)
                .Include(t=> t.TeacherContactInfo)
                .Include(t=> t.TeacherPersonInfo)
                .Include(t=> t.TeacherSkill)
                .Include(t=> t.TeacherDetailImage)
                .FirstOrDefault(t=>t.Id==id);
            return View(teacher);
        }
    }
}
