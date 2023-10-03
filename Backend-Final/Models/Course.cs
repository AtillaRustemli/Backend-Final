namespace Backend_Final.Models
{
    public class Course
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CourseFeature CourseFeature { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<CourseDetail> CourseDetail { get; set; }
        public List<Tag> Tag { get; set; }
        public List<Post> Post { get; set; }
    }
}
