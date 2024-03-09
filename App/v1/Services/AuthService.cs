using System.IdentityModel.Tokens.Jwt;
using System.Text;
using App.v1.Models;
using Microsoft.IdentityModel.Tokens;

namespace App.v1.Services;

using System.Security.Claims;
using System.Security.Cryptography;
using Configuration;
public class AuthService
{
    public string GenerateToken(User user)
    {
        var handler = new JwtSecurityTokenHandler();

        var key = Encoding.ASCII.GetBytes(Configuration.PrivateKay);

        var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            SigningCredentials = credentials,
            Expires = DateTime.UtcNow.AddHours(8),
            Subject = GenerateClaims(user)
        };

        var token = handler.CreateToken(tokenDescriptor);

        return handler.WriteToken(token);
    }

    public JwtSecurityToken DecodeToken(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        return handler.ReadJwtToken(token);
    }

    public string Hash(string value)
    {
        var sha1 = SHA1.Create();

        var bytes = new ASCIIEncoding().GetBytes(value);

        bytes = sha1.ComputeHash(bytes);

        var stringHash = new StringBuilder();

        foreach (var b in bytes) stringHash.Append(b.ToString("x2"));

        return stringHash.ToString();
    }

    public bool CompareHash(string value, string hash)
    {
        string hashedValue = Hash(value);

        return hashedValue.Equals(hash, StringComparison.OrdinalIgnoreCase);
    }

    private static ClaimsIdentity GenerateClaims(User user)
    {
        var ci = new ClaimsIdentity();

        ci.AddClaim(new Claim(ClaimTypes.Name, user.Name));
        foreach (var role in user.Roles) ci.AddClaim(new Claim(ClaimTypes.Role, role));

        return ci;
    }
}