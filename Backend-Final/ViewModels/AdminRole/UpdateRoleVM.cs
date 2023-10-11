using System.ComponentModel.DataAnnotations;

namespace Backend_Final.ViewModels.AdminRole
{
    public class UpdateRoleVM
    {
        [Required]
        public string Name { get; set; }
    }
}
