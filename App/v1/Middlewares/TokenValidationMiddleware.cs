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
        var path = context.Request.Path.Value ?? "";
        if (!path.Contains("auth", StringComparison.CurrentCultureIgnoreCase))
        {
            try
            {
                var token = context.Request.Headers["token"].ToString() ?? "";
                var decoded = _authService.DecodeToken(token);

                var role = decoded.Claims.FirstOrDefault(c => c.Type == "role") ?? throw new Exception();
                context.Items["role"] = role.Value;

                var companyId = decoded.Claims.FirstOrDefault(c => c.Type == "companyId") ?? throw new Exception();
                context.Items["companyId"] = companyId.Value;
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