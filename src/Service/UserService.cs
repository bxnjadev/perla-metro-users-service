using perla_metro_users_service.Dto;
using perla_metro_users_service.Mapper;
using perla_metro_users_service.Model;
using perla_metro_users_service.Repository;

namespace perla_metro_users_service.service;

public class UserService(UserRepository userRepository,
    UserMapper userMapper) : IUserService
{
    
    public async Task<UserDto?> Create(CreationUser creationUser)
    {
        var user = userMapper.ToUser(creationUser);

        if (await userRepository.ExistsAccountByEmail(creationUser.Email))
        {
            return null;
        }
        
        await userRepository.StoreAsync(user);
        return userMapper.ToUserDto(user);
    }

    public async Task<UserDto?> Find(string uuid)
    {
        var user = await userRepository.FindByUuid(uuid);
        if (user == null)
        {
            return null;
        }

        return userMapper.ToUserDto(user);
    }

    public async Task<UserDto?> Delete(string uuid)
    {
        var user = await userRepository.DeleteAsync(uuid);
        if (user == null)
        {
            return null;
        }
        
        return userMapper.ToUserDto(user);
    }

    public async Task<UserDto?> Edit(string uuid,
        EditUser editUser)
    {

        var user = await userRepository.Update(uuid,
            new User
            {
                Name = editUser.Name,
                LastNames = editUser.LastNames,
                Email = editUser.Email
            });
        
        if (user == null)
        {
            return null;
        }

        return userMapper.ToUserDto(user);
    }

    public Task<ICollection<UserDto>> Search(string? name, string? email, bool? searchByIsDesactive)
    {
        
    }
    
}

