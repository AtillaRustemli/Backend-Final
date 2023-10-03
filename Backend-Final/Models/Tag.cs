namespace Backend_Final.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
