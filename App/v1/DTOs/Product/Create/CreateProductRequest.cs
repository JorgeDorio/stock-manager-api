namespace App.v1.DTOs.Product.Create;

public class CreateProductRequest{
    public required string Name { get; set; }
    public required string Category { get; set; }
    public required string Subcategory { get; set; }
    public required string Brand { get; set; }
    public required string Description { get; set; }
    public long CompanyId { get; set; }
}