using perla_metro_users_service.Dto;

namespace perla_metro_users_service.service;

public interface IUserService
{

    Task<UserDto?> Create(CreationUser creationUser);

    Task<UserDto?> Find(string uuid);
    
    Task<UserDto?> Delete(string uuid);

    Task<UserDto?> Edit(string uuid, EditUser editUser);

    Task<ICollection<UserDto>> Search(string? name,
        string? email,
        bool? searchByIsDesactive);

}