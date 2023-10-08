using System.ComponentModel.DataAnnotations;

namespace Backend_Final.ViewModels.AdminSettingKeyValuVM
{
    public class UpdateSettingVM
    {
        [Required]
        public string Key { get; set; }
        public string? Value { get; set; }
        public IFormFile? ImgValue { get; set; }
    }
}
