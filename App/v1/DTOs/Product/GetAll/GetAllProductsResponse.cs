namespace App.v1.DTOs.Product.GetAll;
using App.v1.Models;
public class GetAllProductsResponse(List<Product> products, Pagination pagination)
{
    public IEnumerable<Product> Product { get; set; } = products;
    public Pagination Pagination { get; set; } = pagination;
}