namespace perla_metro_users_service.Model;

/// <summary>
/// This entity represent a user in the PerlaMetro application
/// </summary>

public class User
{
    /// <summary>
    /// UUID V4 for identify the user
    /// </summary>
    
    public Guid Id { get; set; }

    /// <summary>
    /// The user name
    /// </summary>
    
    public string Name { get; set; }

    /// <summary>
    /// The last name user
    /// </summary>
    
    public string LastNames { get; set; }

    /// <summary>
    /// The email user
    /// </summary>
    
    public string Email { get; set; }
    
    /// <summary>
    /// The date user
    /// </summary>
    
    public string Date { get; set; }

    /// <summary>
    /// A flag that is false the user is deleted
    /// </summary>
    
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// The password user encrypt 
    /// </summary>
    
    public string Password { get; set; }

    /// <summary>
    /// The rol user
    /// </summary>
    
    public int Rol { get; set; } = 0;

}