namespace Backend_Final.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specilty { get; set; }
        public string ImgUrl { get; set; }
        public string AboutMe { get; set; }
        public string Description { get; set; }
        public TeacherContactInfo TeacherContactInfo { get; set; }
        public TeacherPersonInfo TeacherPersonInfo { get; set; }
        public TeacherSkill TeacherSkill { get; set; }
        public TeacherSocialMedia TeacherSocialMedia { get; set; }
        public TeacherDetailImage TeacherDetailImage { get; set; }



    }
}
