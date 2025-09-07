using Microsoft.AspNetCore.Mvc;
using perla_metro_users_service.Dto;
using perla_metro_users_service.service;

namespace perla_metro_users_service.Controller;

[ApiController]
[Route("/api/users")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpPost]
    [Route("/create")]
    public async Task<UserDto> Create(
        [FromBody] CreationUser creationUser
    )
    {
        userService.Create(creationUser);
    }

    [HttpGet]
    [Route("/find/{id}")]
    public async Task<UserDto> Find(
        string id)
    {
    }

    [HttpPut]
    [Route("/edit/{id}")]
    public async Task<UserDto> Edit(
        string id,
        [FromBody] EditUser editUser
    )
        
    {
    }

    [HttpDelete]
    [Route("/delete/{id}")]
    public async Task<UserDto> Delete(
        string uuid
    )
    {
    }
}