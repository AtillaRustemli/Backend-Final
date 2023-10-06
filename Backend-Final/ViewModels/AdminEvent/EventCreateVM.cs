using Backend_Final.Models;
using System.ComponentModel.DataAnnotations;

namespace Backend_Final.ViewModels.AdminEvent
{
    public class EventCreateVM
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Desc { get; set; }
        [Required]
        public DateTime OpenTime { get; set; }
        [Required]
        public DateTime CloseTime { get; set; }
        [Required]
        public string Venue { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public IFormFile Image { get; set; }
    }
}
