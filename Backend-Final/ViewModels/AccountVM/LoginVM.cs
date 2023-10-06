using System.ComponentModel.DataAnnotations;

namespace Backend_Final.ViewModels.AccountVM
{
    public class LoginVM
    {
        [Required,StringLength(50)]
        public string UsernameOrEmail { get; set; }
        [Required,DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RemeberMe { get; set; }
    }
}
