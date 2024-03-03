namespace App.v1.DTOs.User;

public class CreateUserDTO
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Secret { get; set; }

}