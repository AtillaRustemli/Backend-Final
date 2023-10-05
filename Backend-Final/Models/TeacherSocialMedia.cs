namespace Backend_Final.Models
{
    public class TeacherSocialMedia
    {
        public int Id { get; set; }
        public string NameUrl { get; set; }
        public string Icon { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

    }
}
