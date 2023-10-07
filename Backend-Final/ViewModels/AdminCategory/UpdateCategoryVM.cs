using System.ComponentModel.DataAnnotations;

namespace Backend_Final.ViewModels.AdminCategory
{
    public class UpdateCategoryVM
    {
        [Required]
        public string Name { get; set; }
    }
}
