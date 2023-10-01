using System.ComponentModel.DataAnnotations;

namespace Backend_Final.ViewModels
{
    public class CommentVM
    {
        public string Name { get; set; }
        [Required,DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
