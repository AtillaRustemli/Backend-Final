namespace Backend_Final.Models
{
    public class SpeakerEvent
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public string SpeakerId { get; set; }
        public Speaker Speaker { get; set; }
    }
}
