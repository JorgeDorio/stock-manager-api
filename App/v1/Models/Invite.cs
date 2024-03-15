namespace App.v1.Models;

public class Invite
{
    public long Id { get; set; }
    public long SenderId { get; set; }
    public long CompanyId { get; set; }
    public required string Email { get; set; }
}