using Microsoft.EntityFrameworkCore;
using perla_metro_users_service.Model;

namespace perla_metro_users_service.Data;

public class ApplicationDbContext : DbContext
{

    public ApplicationDbContext() {}
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
    
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("");
    }
    
}