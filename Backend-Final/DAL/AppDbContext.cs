using Backend_Final.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backend_Final.DAL
{
    public class AppDbContext: IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options):base(options) { 
        
        }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<CommentTitle> CommentTitle { get; set; }
        public DbSet<Subscribers> Subscribers { get; set; }
        public DbSet<SettingsKeyValue> SettingsKeyValue { get; set; }
        public DbSet<Event> Event { get; set; }
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
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<TeacherSkill> TeacherSkill { get; set; }
        public DbSet<TeacherContactInfo> TeacherContactInfo { get; set; }
        public DbSet<TeacherSocialMedia> TeacherSocialMedia { get; set; }
        public DbSet<TeacherPersonInfo> TeacherPersonInfo { get; set; }
        public DbSet<TeacherDetailImage> TeacherDetailImage { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<SpeakerEvent> SpeakerEvent { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            string Adminid = "AdminRoleId";
            string Memberid = "MemberRoleId";
            string SuperAdminid = "SuperAdminRoleId";
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole
                {
                    Id = Adminid,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = Guid.NewGuid().ToString()

                }, new IdentityRole
                {
                    Id = SuperAdminid,
                    Name = "SuperAdmin",
                    NormalizedName = "SUPERADMIN",
                    ConcurrencyStamp = Guid.NewGuid().ToString()

                }, new IdentityRole
                {
                    Id = Memberid,
                    Name = "Member",
                    NormalizedName = "MEMBER",
                    ConcurrencyStamp = Guid.NewGuid().ToString()

                }
                );

        }


    }
}
