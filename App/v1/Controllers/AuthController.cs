using App.v1.DTOs.Auth.Login;
using App.v1.Models;
using App.v1.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.v1.Controllers;

[Route("v1/[controller]")]
[ApiController]
public class AuthController(UserService userService, IMapper mapper) : ControllerBase
{
    private readonly UserService _userService = userService;
    private readonly IMapper _mapper = mapper;

    [HttpPost("Login")]
    public async Task<ActionResult<LoginDTOResponse>> Login(LoginDTORequest loginDTO)
    {
        var user = _mapper.Map<User>(loginDTO);

        var response = await _userService.Login(user);

        return response;
    }
}