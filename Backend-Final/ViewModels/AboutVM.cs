using Backend_Final.Models;

namespace Backend_Final.ViewModels
{
    public class AboutVM
    {
        public About About { get; set; }
        public List<Testimonial> Testimonial { get; set; }
        public List<Teacher> Teacher { get; set; }
        public List<Event> Event { get; set; }
    }
}
