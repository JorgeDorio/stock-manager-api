namespace App.v1.Models;

public class Company
{
    public long Id { get; set; }
    public required string TradeName { get; set; }
    public required string LegalName { get; set; }
    public required string Cnpj { get; set; }
    public bool IsActive { get; set; } = true;
    public ICollection<User>? Users { get; set; }
}