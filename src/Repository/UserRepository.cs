using Microsoft.EntityFrameworkCore;
using perla_metro_users_service.Data;
using perla_metro_users_service.Model;

namespace perla_metro_users_service.Repository;

public class UserRepository(
        ApplicationDbContext dbContext) : IObjectRepository<User>
{

    private readonly DbSet<User> _users = dbContext.Users;
    
    public async Task<User> StoreAsync(User obj)
    {
        await _users.AddAsync(obj);
        await dbContext.SaveChangesAsync();
        return obj;
    }

    public async Task<User?> DeleteAsync(string uuid)
    {
        var user = await FindByUuid(uuid);
        if (user == null)
        {
            return null;
        }

        _users.Remove(user);
        return user;
    }

    public Task<User?> FindByUuid(string uuid)
    {
        var realUuid = Guid.Parse(uuid);
        return _users.FirstOrDefaultAsync(u => u.Id == realUuid);
    }

    public async Task<User?> Update(string uuid, User obj)
    {
        var user = await FindByUuid(uuid);
        if (user == null)
        {
            return null;
        }

        user.Email = obj.Email;
        user.LastNames = obj.LastNames;
        user.Names = obj.Names;
        user.Password = obj.Password;
        await dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<ICollection<User>> AllAsync()
    {
        return await _users.ToListAsync();
    }

    
}