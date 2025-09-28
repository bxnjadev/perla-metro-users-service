using perla_metro_users_service.Authentication.Token;
using perla_metro_users_service.Exception;
using perla_metro_users_service.Repository;
using perla_metro_users_service.Util;

namespace perla_metro_users_service.Authentication;

public class AuthenticationHandler(IUserRepository userRepository,
    IEncryptStrategy encryptStrategy,
    IUserTokenProvider userTokenProvider) : IAuthenticatorHandler
{
    
    public async Task<string> Authenticate(string email, string password)
    {

        var user = await userRepository.FindByEmail(email);
        if (user == null)
        {
            throw new ObjectNotFound();
        }

        if (!user.IsActive)
        {
            throw new UserInactiveException();
        }

        if (!encryptStrategy.Verify(password, user.Password))
        {
            throw new PasswordIncorrectException();
        }

        return userTokenProvider.Token(user);
    }       
    
}