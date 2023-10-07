using System.ComponentModel.DataAnnotations;

namespace Backend_Final.ViewModels.AdminTag
{
    public class CreateTagVM
    {
        [Required]
        public string Name { get; set; }
    }
}
