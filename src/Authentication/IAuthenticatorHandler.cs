namespace perla_metro_users_service.Authentication;

public interface IAuthenticatorHandler
{

    Task<string> Authenticate(string email, string password);

}