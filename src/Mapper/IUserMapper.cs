using perla_metro_users_service.Dto;
using perla_metro_users_service.Model;

namespace perla_metro_users_service.Mapper;

public interface IUserMapper
{

    User ToUser(CreationUser creationUser);

    UserDto ToUserDto(User user);

}