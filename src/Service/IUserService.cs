using perla_metro_users_service.Dto;

namespace perla_metro_users_service.service;

public interface IUserService
{

    /// <summary>
    /// This function create a new user from a request
    /// </summary>
    /// <param name="creationUser">the request for create</param>
    /// <returns>The user created with id</returns>
    
    Task<UserDto?> Create(CreationUser creationUser);

    /// <summary>
    /// Find a user by uuid
    /// </summary>
    /// <param name="uuid">the uuid for find</param>
    /// <returns></returns>
    
    Task<UserDto?> Find(string uuid);
    
    /// <summary>
    /// Delete a user by uuid
    /// </summary>
    /// <param name="uuid">the uuid user for delete</param>
    /// <returns>the user deleted</returns>
    
    Task<UserDto?> Delete(string uuid);

    /// <summary>
    /// Edit a user by uuid
    /// </summary>
    /// <param name="uuid">the uuid user for delete</param>
    /// <param name="editUser">A set parameters for edit</param>
    /// <returns>The edit user with parameters edited</returns>
    
    Task<UserDto?> Edit(string uuid, EditUser editUser);

    /// <summary>
    /// Search a group users by parameters
    /// </summary>
    /// <param name="name">The name user</param>
    /// <param name="email">The email user</param>
    /// <param name="searchByIsDesactive">A flag that is true search all users deleted</param>
    /// <returns>A group users</returns>
    
    Task<ICollection<UserDto>> Search(string? name,
        string? email,
        bool? searchByIsDesactive);

}