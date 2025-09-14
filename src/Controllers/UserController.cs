using Microsoft.AspNetCore.Mvc;
using perla_metro_users_service.Dto;
using perla_metro_users_service.service;

namespace perla_metro_users_service.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
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
    [Route("/api/users/edit/{id}")]
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

    [HttpDelete]
    [Route("/api/users/delete/{id}")]
    public async Task<ActionResult<UserDto>> Delete(
        string uuid
    )
    {
        var userDeleted = await userService.Delete(uuid);
        if (userDeleted == null)
        {
            return BadRequest("The uuid not exists");
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