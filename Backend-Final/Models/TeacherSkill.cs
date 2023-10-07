namespace Backend_Final.Models
{
    public class TeacherSkill
    {
        public int Id { get; set; }
        public string Language { get; set; }
        public double TeamLeader { get; set; }
        public double Development { get; set; }
        public double Design { get; set; }
        public double Innovation { get; set; }
        public double Communication { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
