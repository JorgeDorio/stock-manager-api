using System.IdentityModel.Tokens.Jwt;
using App.v1.DTOs.Auth.Login;
using App.v1.Models;
using App.v1.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.v1.Controllers;

[Route("v1/[controller]")]
[ApiController]
public class AuthController(UserService userService, IMapper mapper, AuthService authService) : ControllerBase
{
    private readonly UserService _userService = userService;
    private readonly AuthService _authService = authService;
    private readonly IMapper _mapper = mapper;

    [HttpPost("Login")]
    public async Task<ActionResult<LoginDTOResponse>> Login(LoginDTORequest loginDTO)
    {
        var user = _mapper.Map<User>(loginDTO);

        var response = await _userService.Login(user);

        return response;
    }

    [HttpGet("{token}")]
    public async Task<JwtPayload> DecodeToken(string token)
    {
        return _authService.DecodeToken(token).Payload;
    }
}