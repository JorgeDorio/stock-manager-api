
namespace App.v1.DTOs.Supplier.GetAll;

using System.Collections.Generic;
using App.v1.Models;

public class GetAllSuppliersResponse(List<Supplier> suppliers, Pagination pagination)
{
    public IEnumerable<Supplier> Suppliers { get; set; } = suppliers;
    public Pagination Pagination { get; set; } = pagination;
}