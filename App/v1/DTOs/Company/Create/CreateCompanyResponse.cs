namespace App.v1.DTOs.Company.Create;

public class CreateCompanyResponse
{
    public long Id { get; set; }
    public required string TradeName { get; set; }
    public required string LegalName { get; set; }
    public required string Cnpj { get; set; }

}