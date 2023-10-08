using Backend_Final.Models;

namespace Backend_Final.ViewModels.AdminCourse
{
    public class CreateCourseVM
    {
        public IFormFile Image { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public CourseFeature CourseFeature { get; set; }
        public CourseDetail CourseDetail { get; set; }
    }
}
