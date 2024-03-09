namespace App.v1.DTOs.Company.Create;

public class CreateCompanyRequest
{
    public required string TradeName { get; set; }
    public required string LegalName { get; set; }
    public required string Cnpj { get; set; }
}