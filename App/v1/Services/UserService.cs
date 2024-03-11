using App.v1.Context;
using App.v1.DTOs.Auth.Login;
using App.v1.DTOs.User;
using App.v1.Models;
using Microsoft.EntityFrameworkCore;

namespace App.v1.Services;

public class UserService(StockContext context, AuthService authService, MailService mailService)
{
    private readonly StockContext _context = context;
    private readonly AuthService _authService = authService;
    private readonly MailService _mailService = mailService;

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

    public async Task<object> GetAllUsers()
    {
        var users = await _context.Users.Select(u => new { u.Id, u.Name, u.Email, u.IsActive, status = u.IsActive ? "Ativo" : "Inativo", company = u.Company.TradeName }).ToListAsync();
        return users;
    }

    public async Task InviteUser(InviteUserRequest inviteUserRequest)
    {
        var db = await _context.Companies.FirstAsync(c => c.Id == inviteUserRequest.CompanyId);

        if (db == null) throw new Exception();

        var token = _authService.GenerateInviteToken(inviteUserRequest, db.TradeName);

        var mail = new Mail(inviteUserRequest.Email, "Convite - Stock Manager",
        "<html><head><style>body { font-family: Arial, sans-serif; }</style></head><body>" +
                            $"<h1 >Você recebeu um convite da empresa {db.TradeName} para se cadastrar no Stock Manager</h1>" +
                            $"<p>Antes de se cadastrar, <strong>confirme se você é coloborador da empresa {db.TradeName}</strong>. Caso não seja, por favor, ignore este e-mail</p>" +
                            $"<p>Para se cadastrar <a href='http://localhost:3000/users/new?token={token}'>clique aqui.</a></p>" +
                            $"<p>Este convide expira em 8 horas!</p>" +
                            "</body></html>");

        _mailService.Send(mail);
    }
}