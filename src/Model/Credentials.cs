namespace perla_metro_users_service.Model;

/// <summary>
/// Represent a set credentials for authentication
/// </summary>

public class Credentials
{

    /// <summary>
    /// The user email
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// The password email
    /// </summary>
    
    public string Password { get; set; } = string.Empty;

}
