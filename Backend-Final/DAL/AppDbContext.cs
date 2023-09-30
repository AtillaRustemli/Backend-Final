using Backend_Final.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_Final.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options) { 
        
        }
        public DbSet<Slider> Slider { get; set; }

    }
}
