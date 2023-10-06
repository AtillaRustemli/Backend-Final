using System.ComponentModel.DataAnnotations;

namespace Backend_Final.ViewModels.AccountVM
{
    public class RegisterVM
    {
        [Required, StringLength(50)]
        public string Username { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password), Compare(nameof(Password))]
        public string RepeatPassword { get; set; }
    }
}
