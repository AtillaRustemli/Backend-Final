using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_Final.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public int CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }
    }
}
