using perla_metro_users_service.Dto;
using perla_metro_users_service.Model;

namespace perla_metro_users_service.Repository;

public interface IUserRepository
{
    
    /// <summary>
    /// Save the user in the datastore
    /// </summary>
    /// <param name="obj">The user object for save</param>
    /// <returns>The user saved</returns>
    
    Task<User> StoreAsync(User obj);
    
    /// <summary>
    /// Delete a user from the datastore 
    /// </summary>
    /// <param name="uuid">The UUID V4 for store</param>
    /// <returns></returns>

    Task<User?> DeleteAsync(string uuid);
    
    /// <summary>
    /// Check if account exists by email
    /// </summary>
    /// <param name="email">The email name</param>
    /// <returns></returns>

    Task<bool> ExistsAccountByEmail(string email);

    /// <summary>
    /// Find a user by her email in the datastore
    /// </summary>
    /// <param name="email">The email for search</param>
    /// <returns>The user founded</returns>
    
    Task<User?> FindByEmail(string email);
    
    /// <summary>
    /// Find user by uuid
    /// </summary>
    /// <param name="uuid">The UUID V4 for search</param>
    /// <returns>The user founded</returns>
    
    Task<User?> FindByUuid(string uuid);

    /// <summary>
    /// Update a user from by UUID
    /// </summary>
    /// <param name="uuid">The user UUID V4 for identify user</param>
    /// <param name="obj">A group parameters for edit</param>
    /// <returns></returns>
    
    Task<User?> Update(string uuid, User obj);

    /// <summary>
    /// Get all users
    /// </summary>
    /// <returns>All users from datastore</returns>
    Task<ICollection<User>> AllAsync();

    Task<ICollection<User>> Search(
        string? name,
        string? email,
        bool? searchByIsDesactive
    );

}