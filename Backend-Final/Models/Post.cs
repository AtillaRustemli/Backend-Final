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
    }
}
