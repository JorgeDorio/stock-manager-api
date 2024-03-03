using App.v1.Context;
using App.v1.DTOs.Auth.Login;
using App.v1.Models;
using Microsoft.EntityFrameworkCore;

namespace App.v1.Services;

public class UserService(StockContext context, AuthService authService)
{
    private readonly StockContext _context = context;
    private readonly AuthService _authService = authService;

    public async Task<LoginDTOResponse> Login(User user)
    {
        var dbUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email) ?? throw new Exception();

        var secretIsValid = _authService.CompareHash(user.Secret, dbUser.Secret);

        if (!secretIsValid) throw new Exception();

        var token = _authService.GenerateToken(dbUser);
        return new LoginDTOResponse(token);
    }

    public async Task<User> CreateUser(User user)
    {
        user.Secret = _authService.Hash(user.Secret);

        var dbUser = await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return dbUser.Entity;
    }
}