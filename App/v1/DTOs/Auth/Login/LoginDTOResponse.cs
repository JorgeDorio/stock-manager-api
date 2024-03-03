namespace App.v1.DTOs.Auth.Login;

public class LoginDTOResponse(string token)
{
    public string Token { get; set; } = token;
}