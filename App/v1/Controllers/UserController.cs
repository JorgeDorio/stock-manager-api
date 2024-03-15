using App.v1.DTOs.User;
using App.v1.DTOs.User.Edit;
using App.v1.Enums;
using App.v1.Models;
using App.v1.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.v1.Controllers;

[Route("v1/[controller]")]
[ApiController]
public class UserController(UserService userService, IMapper mapper) : ControllerBase
{
    private readonly UserService _userService = userService;
    private readonly IMapper _mapper = mapper;

    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(CreateUserDTO createUserDTO)
    {
        var user = _mapper.Map<User>(createUserDTO);

        var result = await _userService.CreateUser(user);

        return result;
    }

    [HttpGet]
    public async Task<object> GetAllUsers()
    {
        var role = HttpContext.Items["role"].ToString();
        var companyId = long.Parse(HttpContext.Items["companyId"].ToString());

        var result = await _userService.GetAllUsers(role, companyId);
        return result;
    }

    [HttpPost("invite")]
    public async Task InviteUser(InviteUserRequest inviteUserRequest)
    {
        await _userService.InviteUser(inviteUserRequest);
    }

    [HttpPut]
    public async Task EditUser(EditUserRequest editUserRequest)
    {
        var user = _mapper.Map<User>(editUserRequest);
        await _userService.EditUser(user);
    }
}