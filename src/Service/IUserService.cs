using perla_metro_users_service.Dto;

namespace perla_metro_users_service.service;

public interface IUserService
{

    /// <summary>
    /// Create a new 
    /// </summary>
    /// <param name="creationUser"></param>
    /// <returns></returns>
    
    Task<UserDto?> Create(CreationUser creationUser);

    Task<UserDto?> Find(string uuid);
    
    Task<UserDto?> Delete(string uuid);

    Task<UserDto?> Edit(string uuid, EditUser editUser);

    Task<UserDto?> EditPassword(string uuid, string password,
        string repeatPassword);

    Task<ICollection<UserDto>> Search(string? name,
        string? email,
        bool? searchByIsDesactive);

}