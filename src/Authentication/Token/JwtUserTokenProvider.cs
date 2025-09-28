using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using perla_metro_users_service.Model;
using perla_metro_users_service.Util;

namespace perla_metro_users_service.Authentication.Token;

public class JwtUserTokenProvider: IUserTokenProvider
{
    
    private readonly string _jwtSecret;
    private readonly string _validIssuer;
    private readonly string _validAudience;
    private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
    
    public JwtUserTokenProvider(IConfiguration configuration)
    {
        _jwtSecret = configuration["JWT:Secret"];
        _validIssuer = configuration["JWT:ValidIssuer"];
        _validAudience = configuration["JWT:ValidAudience"];
        _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
    }

    
    public string Token(User user)
    {
        var roleId = user.Rol;
        var roleName = Roles.GetNameRol(roleId);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, roleName)
        };

        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecret));
        DateTime? expiration = DateTime.UtcNow.AddHours(1);
        var credentials = new SigningCredentials(
            authSigningKey,
            SecurityAlgorithms.HmacSha256
        );

        var token = new JwtSecurityToken(
            claims: claims,
            expires: expiration,
            signingCredentials: credentials
        );

        return _jwtSecurityTokenHandler
            .WriteToken(token);
    }
}

