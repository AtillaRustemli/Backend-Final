using System.ComponentModel.DataAnnotations;

namespace Backend_Final.Models
{
    public class TeacherContactInfo
    {
        public int Id { get; set; }
        public string Skype { get; set; }
        [Required]
        public string Email { get; set; }
        public string Number { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
