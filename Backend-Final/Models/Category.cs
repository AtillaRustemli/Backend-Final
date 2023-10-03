namespace Backend_Final.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Event> Event { get; set; }
        public List<Blog> Blog { get; set; }
        public List<Course> Course { get; set; }

    }
}
