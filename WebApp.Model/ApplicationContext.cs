using Microsoft.EntityFrameworkCore;
using WebApp.Model.DatabaseModels;

namespace WebApp.Model
{
    public class ApplicationContext:DbContext
    {
        public DbSet<User> Users { get; set; } 
        public DbSet<Product> Products { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options) {}
    }
}