using Microsoft.EntityFrameworkCore;
using perla_metro_users_service.Data;
using perla_metro_users_service.Model;

namespace perla_metro_users_service.Repository;

public class UserRepository(
    ApplicationDbContext dbContext) : IUserRepository
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

        user.IsActive = false;
        await dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<bool> ExistsAccountByEmail(string email)
    {
        var user = await _users.Where(u => u.Email == email)
            .FirstOrDefaultAsync();
        return user != null;
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
        user.Name = obj.Name;
        user.Password = obj.Password;
        await dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<ICollection<User>> AllAsync()
    {
        return await _users.ToListAsync();
    }

    public async Task<ICollection<User>> Search(string? name,
        string? email,
        bool? searchByIsDesactive)
    {

        IQueryable<User> searched = dbContext.Users;
        
        if (email != null)
        {
            searched = searched.Where(u => u.Email == email);
        }

        if (searchByIsDesactive != null)
        {
            searched = searched.Where(u => !u.IsActive);
        }
        else
        {
            searched = searched.Where(u => u.IsActive);
        }

        return await searched.ToListAsync();
    }
}