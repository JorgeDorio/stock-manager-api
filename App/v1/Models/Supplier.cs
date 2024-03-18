namespace App.v1.Models;

public class Supplier
{
    public long Id { get; set; }
    public long CompanyId { get; set; }
    public required string TradeName { get; set; }
    public required string LegalName { get; set; }
    public required string Cnpj { get; set; }

    public required Company Company { get; set; }
}