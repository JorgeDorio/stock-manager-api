using App.v1.Enums;

namespace App.v1.Models;

public class User
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Secret { get; set; }
    public bool IsActive { get; set; } = true;
    public Roles Role { get; set; } = Roles.DEFAULT;
    public long CompanyId { get; set; }
    public required Company Company { get; set; }
}