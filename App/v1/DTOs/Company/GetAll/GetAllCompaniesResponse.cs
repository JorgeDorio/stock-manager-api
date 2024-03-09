
namespace App.v1.DTOs.Company.GetAll;

using System.Collections.Generic;
using App.v1.Models;
public class GetAllCompaniesResponse
{
    public GetAllCompaniesResponse(List<Company> companies, Pagination pagination)
    {
        Companies = companies;
        Pagination = pagination;
    }

    public IEnumerable<Company> Companies { get; set; }
    public Pagination Pagination { get; set; } = new Pagination();
}