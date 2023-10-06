using Backend_Final.Models;

namespace Backend_Final.ViewModels
{
    public class SearchVM
    {
        public SearchVM(List<Blog> blog,List<Event> @event,List<Course> course)
        {
            Blog = blog;
            Event = @event;
            Course = course;
        }
        public List<Blog>? Blog { get; set; }
        public List<Event>? Event { get; set; }
        public List<Course>? Course { get; set; }
    }
}
