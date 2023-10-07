using Backend_Final.Models;
using System.ComponentModel.DataAnnotations;

namespace Backend_Final.ViewModels.AdminTeacher
{
    public class CreateTeacherVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Desc { get; set; }
        [Required]
        public string Specilty { get; set; }
        [Required]
        public string AboutMe { get; set; }
        [Required]
        public IFormFile Image { get; set; }
        [Required]
        public TeacherContactInfo TeacherContactInfo { get; set; }
        [Required]
        public TeacherPersonInfo TeacherPersonInfo { get; set; }
        [Required]
        public TeacherSocialMedia TeacherSocialMedia { get; set; }
        [Required]
        public TeacherSkill TeacherSkill { get; set; }
    }
}
