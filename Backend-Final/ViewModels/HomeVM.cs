using Backend_Final.Models;

namespace Backend_Final.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Slider { get; set; }
        public List<Event> Event { get; set; }
        public List<Blog> Blog { get; set; }
        public List<Course> Course { get; set; }
        public Dictionary<string,string> SettingsKeyValue { get; set; }
        public List<Testimonial> Testimonial { get; set; }
        public List<NoticeAreaRight> NoticeAreaRight { get; set; }
        public WhyChooseUs WhyChooseUs { get; set; }
    }
}
