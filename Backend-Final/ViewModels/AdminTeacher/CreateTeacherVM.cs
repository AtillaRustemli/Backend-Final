using Backend_Final.Models;
using System.ComponentModel.DataAnnotations;

namespace Backend_Final.ViewModels.AdminTeacher
{
    public class CreateTeacherVM
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Specilty { get; set; }
        public string AboutMe { get; set; }
        public IFormFile Image { get; set; }
        public TeacherContactInfo TeacherContactInfo { get; set; }
        public TeacherPersonInfo TeacherPersonInfo { get; set; }
        public TeacherSocialMedia TeacherSocialMedia { get; set; }
        public TeacherSkill TeacherSkill { get; set; }
    }
}
