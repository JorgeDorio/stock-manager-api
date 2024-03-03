namespace App.v1.DTOs.Auth.Login;

public class LoginDTORequest
{
    public required string Email { get; set; }
    public required string Secret { get; set; }
}