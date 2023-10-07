using System.ComponentModel.DataAnnotations;

namespace Backend_Final.ViewModels.AdminCategory
{
    public class CreateCategoryVM
    {
        [Required]
        public string Name { get; set; }
    }
}
