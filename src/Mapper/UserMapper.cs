using perla_metro_users_service.Dto;
using perla_metro_users_service.Model;
using perla_metro_users_service.Util;

namespace perla_metro_users_service.Mapper;

public class UserMapper(IEncryptStrategy encryptStrategy) : IUserMapper
{
    
    public User ToUser(CreationUser creationUser)
    {
        var passwordEncrypt = encryptStrategy.Encrypt(creationUser.Password);
        var dateTime = DateTime.Now;
        
        return new User
        {
            Name = creationUser.Name,
            Password = passwordEncrypt,
            LastNames = creationUser.LastNames,
            Email = creationUser.Email,
            Date = dateTime.Date.ToString(),
            IsActive = true
        };
    }

    public UserDto ToUserDto(User user)
    {
        return new UserDto
        {
            Uuid = user.Id.ToString(),
            Name = user.Name,
            LastNames = user.LastNames,
            Email = user.Email,
            Date = user.Date
        };
    }
    
    
}