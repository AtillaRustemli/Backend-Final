namespace Backend_Final.Models
{
    public class TeacherSkill
    {
        public int Id { get; set; }
        public string Skill { get; set; }
        public double Percent { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
