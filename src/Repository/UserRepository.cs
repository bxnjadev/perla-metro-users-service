using Microsoft.EntityFrameworkCore;
using perla_metro_users_service.Data;
using perla_metro_users_service.Model;

namespace perla_metro_users_service.Repository;

public class UserRepository(
        ApplicationDbContext dbContext) : IObjectRepository<User>
{

    private DbSet<User> _users = dbContext.Users;
    
    public Task<User> StoreAsync(User obj)
    {
        
    }

    public Task<User?> DeleteAsync(string uuid)
    {
        
    }

    public Task<User?> FindByUuid(string uuid)
    {
        
    }

    public Task<User?> Update(string uuid, User obj)
    {
        
    }

    public Task<ICollection<User>> AllAsync()
    {
        
    }

    
}