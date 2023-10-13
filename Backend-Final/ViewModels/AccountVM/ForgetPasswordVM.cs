using Backend_Final.Models;
using System.ComponentModel.DataAnnotations;

namespace Backend_Final.ViewModels.AccountVM
{
    public class ForgetPasswordVM
    {
        public AppUser? appUser { get; set; }
        [Required,DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password),Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
