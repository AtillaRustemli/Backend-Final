using Backend_Final.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_Final.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options) { 
        
        }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<CommentTitle> CommentTitle { get; set; }
        public DbSet<Subscribers> Subscribers { get; set; }
        public DbSet<SettingsKeyValue> SettingsKeyValue { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<EventDetailImage> EventDetailImage { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<CourseFeature> CourseFeature { get; set; }
        public DbSet<CourseDetail> CourseDetail { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<Testimonial> Testimonial { get; set; }
        public DbSet<NoticeAreaRight> NoticeAreaRight { get; set; }
        public DbSet<WhyChooseUs> WhyChooseUs { get; set; }
        public DbSet<CourseDetaiIImage> CourseDetaiIImage { get; set; }


    }
}
