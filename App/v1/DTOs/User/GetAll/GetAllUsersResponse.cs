namespace App.v1.DTOs.User.GetAll;

public class GetAllUsersResponse{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public bool IsActive { get; set; } = true;
    public required string[] Roles { get; set; } = [];
}