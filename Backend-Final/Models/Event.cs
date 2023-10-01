namespace Backend_Final.Models
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Desc { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
        public string Venue { get; set; }
        public Speakers Speakers { get; set; }
    }
}
