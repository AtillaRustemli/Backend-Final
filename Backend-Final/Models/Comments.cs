using System.ComponentModel.DataAnnotations;

namespace Backend_Final.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public string? BlogComment { get; set; }
        public string? EventComment { get; set; }
        public string? CourseComment { get; set; }
        [Required]
        public string Name { get; set; }
        [Required,DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
