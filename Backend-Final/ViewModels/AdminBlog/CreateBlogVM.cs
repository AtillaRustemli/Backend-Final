using System.ComponentModel.DataAnnotations;

namespace Backend_Final.ViewModels.AdminBlog
{
    public class CreateBlogVM
    {
        [Required]
        public IFormFile Image { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Desc { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
