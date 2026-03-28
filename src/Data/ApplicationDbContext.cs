using Microsoft.EntityFrameworkCore;
using perla_metro_users_service.Model;

namespace perla_metro_users_service.Data;

/// <summary>
/// The manage database system
/// </summary>

public class ApplicationDbContext : DbContext
{

    public ApplicationDbContext() {}
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
    
    
    /// <summary>
    /// A DataSource handler for User Entity
    /// </summary>
    public DbSet<User> Users { get; set; }
    
    /// <summary>
    /// This method linked the primary key and establish others configuration with postgres
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id);
        });
        
        modelBuilder.Entity<User>()
            .Property(u => u.Id)
            .HasDefaultValueSql("gen_random_uuid()");
    }
    
}