using Backend_Final.DAL;
using Backend_Final.Helper;
using Backend_Final.Models;
using Backend_Final.Models.Emails;
using Backend_Final.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Backend_Final
{
    public static class RegisterServices
    {
        public static void Register(this IServiceCollection services,IConfiguration config)
        {
            services.AddControllersWithViews();

            services.AddHttpContextAccessor();
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            services.Configure<EmailConfig>(config.GetSection(nameof(EmailConfig)));
            services.AddScoped<EmailConfig>();
            services.AddIdentity<AppUser, IdentityRole>(identityOptions =>
            {
                identityOptions.SignIn.RequireConfirmedEmail = true;
                identityOptions.Password.RequireNonAlphanumeric = true;
                identityOptions.Password.RequiredLength = 8;
                identityOptions.Password.RequireDigit = true;
                identityOptions.Password.RequireLowercase = true;
                identityOptions.Password.RequireUppercase = true;

                identityOptions.User.RequireUniqueEmail = true;
                identityOptions.Lockout.MaxFailedAccessAttempts = 5;
                identityOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(20);
                identityOptions.Lockout.AllowedForNewUsers = true;
            })
               .AddDefaultTokenProviders()
               .AddEntityFrameworkStores<AppDbContext>()
               .AddErrorDescriber<CustomIdentityErrorDescriber>();


        }
    }
}
