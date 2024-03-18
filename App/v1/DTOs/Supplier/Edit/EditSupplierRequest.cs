namespace App.v1.DTOs.Supplier.Edit;

public class EditSupplierRequest
{
    public long Id { get; set; }
    public required string TradeName { get; set; }
    public required string LegalName { get; set; }
    public required string Cnpj { get; set; }
    public bool IsActive { get; set; }
}