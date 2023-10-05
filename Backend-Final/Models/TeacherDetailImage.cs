namespace Backend_Final.Models
{
    public class TeacherDetailImage
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
