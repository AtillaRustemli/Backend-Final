using Backend_Final.DAL;
using Backend_Final.Helper;
using Backend_Final.Models;
using Backend_Final.Models.Emails;
using Backend_Final.Services;
using Backend_Final.Services.AdminServices.AdminEventServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace Backend_Final
{
    public static class RegisterServices
    {
        public static void Register(this IServiceCollection services,IConfiguration config)
        {
            StripeConfiguration.ApiKey = "sk_test_51OAacTD8Iq5wIjaHLvsXtWdivpezezesic9qjBQwOdxEzibO4brHxVPnWPK0Y9DyVzOhXdiEbX0e9bUX30m8pDDq00x71bYBSY";
            //StripeConfiguration.ApiKey = config.GetSection("Stripe")["SecretKey"];
            services.Configure<StripeSettings>(config.GetSection("Stripe"));
            services.AddControllersWithViews();

            services.AddHttpContextAccessor();
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            services.Configure<EmailConfig>(config.GetSection(nameof(EmailConfig)));
            services.AddScoped<EmailConfig>();

            services.AddScoped<IEventService, EventsService>();

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
