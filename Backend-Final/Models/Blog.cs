namespace Backend_Final.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Post> Post { get; set; }
        public List<Tag> Tag { get; set; }

    }
}
