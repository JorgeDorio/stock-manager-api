namespace App.v1.Models;

public class Product
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required string Category { get; set; }
    public required string Subcategory { get; set; }
    public required string Brand { get; set; }
    public required string Description { get; set; }
    public required Company Company { get; set; }
    public long CompanyId { get; set; }
}