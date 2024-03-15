using App.v1.Enums;

namespace App.v1.DTOs.User.Edit;

public class EditUserRequest {
    public long Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public bool IsActive { get; set; } = true;
    public Roles Role { get; set; }
    public long CompanyId { get; set; }
}