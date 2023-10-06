namespace Backend_Final.Models
{
    public class Speaker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specilty { get; set; }
        public string ImgUrl { get; set; }
        public List<SpeakerEvent> SpeakerEvent { get; set; }

    }
}
