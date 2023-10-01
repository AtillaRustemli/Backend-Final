using System.ComponentModel.DataAnnotations;

namespace Backend_Final.Models
{
    public class Subscribers
    {
        public int Id { get; set; }
        [Required,DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
