namespace Backend_Final.Models
{
    public class Speaker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specilty { get; set; }
        public int? EventId { get; set; }
        public Event Event { get; set; }

    }
}
