using System.Security.Claims;
using App.v1.Enums;
using App.v1.Services;

namespace App.v1.Middlewares;

public class TokenValidationMiddleware(RequestDelegate next, AuthService authService)
{
    private readonly RequestDelegate _next = next;
    private readonly AuthService _authService = authService;

    public async Task Invoke(HttpContext context)
    {
        if (!context.Request.Path.Value.ToLower().Contains("auth"))
        {
            try
            {
                var decoded = _authService.DecodeToken(context.Request.Headers["token"]);
                context.Items["role"] = decoded.Claims.FirstOrDefault(c => c.Type == "role").Value;
                context.Items["companyId"] = decoded.Claims.FirstOrDefault(c => c.Type == "companyId").Value;
            }
            catch (Exception)
            {
                context.Response.StatusCode = 401;
                return;
            }
        }
        await _next(context);
    }
}