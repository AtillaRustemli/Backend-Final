using Backend_Final.Models;
using System.ComponentModel.DataAnnotations;

namespace Backend_Final.ViewModels.AdminCourse
{
    public class UpdateCourseVM
    {

        [Required]
        public IFormFile Image { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Desc { get; set; }
        [Required]
        public CourseFeature CourseFeature { get; set; }
        [Required]
        public CourseDetail CourseDetail { get; set; }
    }
}
