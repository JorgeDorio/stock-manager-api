namespace App.v1.DTOs.User;

public class InviteUserRequest
{
    public required string Email { get; set; }
    public required long CompanyId { get; set; }
}