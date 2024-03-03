namespace App.v1.Models;

public class User
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Secret { get; set; }
    public bool IsActive { get; set; } = true;
    public required string[] Roles { get; set; } = [];
}