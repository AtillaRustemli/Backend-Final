namespace Backend_Final.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
        public string Venue { get; set; }
        public DateTime Date { get; set; }
        public string ImgUrl { get; set; }
        public List<Speaker> Speakers { get; set; }
        public EventDetailImage EventDetailImage { get; set; }
        public List<Post> Post { get; set; }
        public List<Tag> Tag { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
