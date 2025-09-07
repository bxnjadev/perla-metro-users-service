using Microsoft.EntityFrameworkCore;

namespace perla_metro_users_service.Model;

public class User
{
    public Guid Id { get; set; }

    public string Names { get; set; }

    public string LastNames { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }
    
}