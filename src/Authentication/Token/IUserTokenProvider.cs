using perla_metro_users_service.Model;

namespace perla_metro_users_service.Authentication.Token;

public interface IUserTokenProvider
{

    string Token(User user);

}