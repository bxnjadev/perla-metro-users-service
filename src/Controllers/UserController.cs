using Microsoft.AspNetCore.Mvc;
using perla_metro_users_service.Authentication;
using perla_metro_users_service.Authentication.Token;
using perla_metro_users_service.Dto;
using perla_metro_users_service.Exception;
using perla_metro_users_service.Model;
using perla_metro_users_service.service;

namespace perla_metro_users_service.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(
    IUserService userService,
    IAuthenticatorHandler authenticatorHandler
) : ControllerBase
{
    
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

    [HttpPatch]
    [Route("/api/users/{uuid}/password")]
    public async Task<ActionResult<UserDto>> UpdatePassword(
        string uuid,
        [FromBody] EditPassword editPassword)
    {
        try
        {
            return Ok(await userService.EditPassword(uuid,
                editPassword.Password,
                editPassword.RepeatPassword
            ));
        }
        catch (NotEqualsPasswordException)
        {
            return BadRequest("The password not equals");
        }
        catch (ObjectNotFound)
        {
            return NotFound("The user not found");
        }
    }


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