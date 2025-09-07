using Microsoft.EntityFrameworkCore;

namespace perla_metro_users_service.Model;

public class User
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string LastNames { get; set; }

    public string Email { get; set; }
    
    public string Date { get; set; }

    public bool IsActive { get; set; } = true;

    public string Password { get; set; }
    
}