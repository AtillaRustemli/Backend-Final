using Backend_Final.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Backend_Final.ViewModels.AdminUser
{
    public class UpdateUserVM
    {
        [Required]
        public AppUser AppUser { get; set; }
        [Required]
        public IList<string> UserRole { get; set; }
        public List<IdentityRole>? Roles { get; set; }
    }
}
