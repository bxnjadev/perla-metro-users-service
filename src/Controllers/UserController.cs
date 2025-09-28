using Microsoft.AspNetCore.Mvc;
using perla_metro_users_service.Authentication;
using perla_metro_users_service.Authentication.Token;
using perla_metro_users_service.Dto;
using perla_metro_users_service.Exception;
using perla_metro_users_service.Model;
using perla_metro_users_service.service;

namespace perla_metro_users_service.Controllers;

/// <summary>
/// Controller that contains the all http method users
/// </summary>
/// <param name="userService">The user service for handle users</param>
/// <param name="authenticatorHandler">The authentication handler for manage the authentication</param>

[ApiController]
[Route("api/[controller]")]
public class UserController(
    IUserService userService,
    IAuthenticatorHandler authenticatorHandler
) : ControllerBase
{
    
    /// <summary>
    /// Authenticate with the system
    /// </summary>
    /// <param name="credentials">A group credentials for access</param>
    /// <returns>A JWT with the date of users</returns>
    
    [HttpPost]
    [Route("/api/auth/")]
    public async Task<ActionResult<string>> Login(
        [FromBody] Credentials credentials
    )
    {
        try
        {
            var token = await authenticatorHandler.Authenticate(
                credentials.Email,
                credentials.Password
            );

            return Ok(token);
        }
        catch (ObjectNotFound objectNotFound)
        {
            return BadRequest("Usuario no encontrado");
        }
        catch (UserInactiveException userInactiveException)
        {
            return BadRequest("Usuario esta inactivo");
        }
        catch (PasswordIncorrectException passwordIncorrectException)
        {
            return Unauthorized("Clave incorrecta");
        }
        
    }

    /// <summary>
    /// Create a new users 
    /// </summary>
    /// <param name="creationUser">The request user</param>
    /// <returns>The user created with her UUID V4</returns>
    
    [HttpPost]
    [Route("/api/users/create")]
    public async Task<ActionResult<UserDto>> Create(
        [FromBody] CreationUser creationUser
    )
    {
        var user = await userService.Create(creationUser);
        if (user == null)
        {
            return BadRequest("This email already exists");
        }

        return Ok(user);
    }
    
    /// <summary>
    /// Find a user by her UUID V4
    /// </summary>
    /// <param name="uuid">The UUID V4 for find</param>
    /// <returns>The user founded</returns>

    [HttpGet]
    [Route("/api/users/find/{uuid}")]
    public async Task<ActionResult<UserDto>> Find(
        string uuid)
    {
        var user = await userService.Find(uuid);
        if (user == null)
        {
            return BadRequest("User not found");
        }

        return Ok(user);
    }
    
    /// <summary>
    /// Edit a user by group of parameters
    /// </summary>
    /// <param name="uuid">The UUID user for usted</param>
    /// <param name="editUser">A group of parameters for edit</param>
    /// <returns></returns>

    [HttpPut]
    [Route("/api/users/edit/{uuid}")]
    public async Task<ActionResult<UserDto>> Edit(
        string uuid,
        [FromBody] EditUser editUser
    )
    {
        var user = await userService.Edit(uuid, editUser);
        if (user == null)
        {
            return BadRequest("user not found");
        }

        return Ok(user);
    }


    /// <summary>
    /// Delete a user from UUID V4
    /// </summary>
    /// <param name="uuid">The UUID V4 for delete</param>
    /// <returns>The user deleted</returns>
    
    [HttpDelete]
    [Route("/api/users/delete/{uuid}")]
    public async Task<ActionResult<UserDto>> Delete(
        string uuid
    )
    {
        var userDeleted = await userService.Delete(uuid);
        if (userDeleted == null)
        {
            return BadRequest("The user not exists");
        }

        return Ok(userDeleted);
    }
    
    /// <summary>
    /// Search a user from a group filters
    /// </summary>
    /// <param name="name">The username</param>
    /// <param name="email">The email</param>
    /// <param name="searchByIsActive">A flag that is true only will search users active</param>
    /// <returns></returns>

    [HttpGet]
    [Route("/api/users/search")]
    public async Task<ActionResult<List<UserDto>>> Search(
        [FromQuery] string? name,
        [FromQuery] string? email,
        [FromQuery] bool? searchByIsActive
    )
    {
        return Ok(
            await userService.Search(name,
                email,
                searchByIsActive)
        );
    }
    
}