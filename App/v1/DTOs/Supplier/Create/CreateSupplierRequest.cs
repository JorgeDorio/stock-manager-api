namespace App.v1.DTOs.Supplier.Create;

public class CreateSupplierRequest
{
    public required string TradeName { get; set; }
    public required string LegalName { get; set; }
    public required string Cnpj { get; set; }
}