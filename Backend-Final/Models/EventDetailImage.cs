namespace Backend_Final.Models
{
    public class EventDetailImage
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
