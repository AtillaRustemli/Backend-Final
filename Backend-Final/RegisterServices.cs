using Backend_Final.DAL;
using Microsoft.EntityFrameworkCore;

namespace Backend_Final
{
    public static class RegisterServices
    {
        public static void Register(this IServiceCollection services,IConfiguration config)
        {
            services.AddControllersWithViews();
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
            
         
        }
    }
}
