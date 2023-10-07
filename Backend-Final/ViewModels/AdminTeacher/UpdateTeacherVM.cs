using Backend_Final.Models;
using System.ComponentModel.DataAnnotations;

namespace Backend_Final.ViewModels.AdminTeacher
{
    public class UpdateTeacherVM
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Desc { get; set; }
        [Required]
        public string? Specilty { get; set; }
        [Required]
        public string? AboutMe { get; set; }
        [Required]
        public IFormFile? Image { get; set; }
        public TeacherContactInfo? TeacherContactInfo { get; set; }
        public TeacherPersonInfo? TeacherPersonInfo { get; set; }
        public TeacherSocialMedia? TeacherSocialMedia { get; set; }
        public TeacherSkill? TeacherSkill { get; set; }
    }
}
