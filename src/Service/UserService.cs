using perla_metro_users_service.Dto;
using perla_metro_users_service.Exception;
using perla_metro_users_service.Mapper;
using perla_metro_users_service.Model;
using perla_metro_users_service.Repository;
using perla_metro_users_service.Util;

namespace perla_metro_users_service.service;

public class UserService(IUserRepository userRepository,
    IUserMapper userMapper,
    IEncryptStrategy encryptStrategy) : IUserService
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
                Email = editUser.Email,
                Password = encryptStrategy.Encrypt(editUser.Password)
            });
        
        if (user == null)
        {
            return null;
        }

        return userMapper.ToUserDto(user);
    }

    public async Task<UserDto?> EditPassword(string uuid, string password, string repeatPassword)
    {
        if (password != repeatPassword)
        {
            throw new NotEqualsPasswordException();
        }

        var user = await userRepository.FindByUuid(uuid);
        if (user == null)
        {
            throw new ObjectNotFound();
        }

        user.Password = encryptStrategy.Encrypt(password);
        user = await userRepository.Update(uuid, user);
        return userMapper.ToUserDto(user);
    }

    public async Task<ICollection<UserDto>> Search(string? name, string? email, bool? searchByIsDesactive)
    {
        var usersSearched = await userRepository.Search(name,
            email,
            searchByIsDesactive);

        var usersDto = new List<UserDto>();
        foreach (var user in usersSearched)
        {
            usersDto.Add(userMapper.ToUserDto(user));
        }

        return usersDto;
    }
    
}

