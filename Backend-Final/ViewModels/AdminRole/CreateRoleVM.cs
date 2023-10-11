using System.ComponentModel.DataAnnotations;

namespace Backend_Final.ViewModels.AdminRole
{
    public class CreateRoleVM
    {
        [Required]
        public string Name { get; set; }
    }
}
