using System.ComponentModel.DataAnnotations;

namespace Backend_Final.ViewModels.AdminTag
{
    public class UpdateTagVM
    {
        [Required]
        public string Name { get; set; }
    }
}
