using perla_metro_users_service.Dto;
using perla_metro_users_service.Model;

namespace perla_metro_users_service.Repository;

public interface IUserRepository
{
    Task<User> StoreAsync(User obj);

    Task<User?> DeleteAsync(string uuid);

    Task<bool> ExistsAccountByEmail(string email);

    Task<User?> FindByEmail(string email);

    Task<User?> FindByUuid(string uuid);

    Task<User?> Update(string uuid, User obj);

    Task<ICollection<User>> AllAsync();

    Task<ICollection<User>> Search(
        string? name,
        string? email,
        bool? searchByIsDesactive
    );

}