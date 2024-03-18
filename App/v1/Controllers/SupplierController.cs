using App.v1.DTOs.Supplier.Create;
using App.v1.DTOs.Supplier.Edit;
using App.v1.DTOs.Supplier.GetAll;
using App.v1.Models;
using App.v1.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.v1.Controllers;

[Route("v1/[controller]")]
[ApiController]
public class SupplierController(IMapper mapper, SupplierService supplierService) : ControllerBase
{
    private readonly IMapper _mapper = mapper;
    private readonly SupplierService _supplierService = supplierService;

    [HttpPost]
    public async Task<CreateSupplierResponse> CreateSupplier(CreateSupplierRequest createSupplierRequest)
    {
        var companyIdString = (HttpContext.Items["companyId"]?.ToString()) ?? throw new Exception();
        var companyId = long.Parse(companyIdString);
        
        var supplier = _mapper.Map<Supplier>(createSupplierRequest);
        supplier.CompanyId = companyId;

        var result = await _supplierService.CreateSupplier(supplier);

        return _mapper.Map<CreateSupplierResponse>(result);
    }

    [HttpPut]
    public async Task EditSupplier(EditSupplierRequest editSupplierRequest)
    {
        var supplier = _mapper.Map<Supplier>(editSupplierRequest);

        await _supplierService.EditSupplier(supplier);
    }

    [HttpGet]
    public async Task<GetAllSuppliersResponse> GetSuppliers([FromQuery] Pagination pagination)
    {
        var result = await _supplierService.GetSuppliers(pagination);
        return result;
    }

    [HttpGet("tolist")]
    public async Task<object> GetNamesAndIds()
    {
        var result = await _supplierService.GetNamesAndIds();
        return result;
    }

    [HttpDelete("{id}")]
    public async Task RemoveSupplier(long id)
    {
        await _supplierService.RemoveSupplier(id);
    }
}