using App.v1.DTOs.Product.Create;
using App.v1.DTOs.Product.Edit;
using App.v1.DTOs.Product.GetAll;
using App.v1.Models;
using App.v1.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.v1.Controllers;

[Route("v1/[controller]")]
[ApiController]
public class ProductController(IMapper mapper, ProductService productService) : ControllerBase
{
    private readonly IMapper _mapper = mapper;
    private readonly ProductService _productService = productService;

    [HttpPost]
    public async Task CreateProduct(CreateProductRequest createProductRequest)
    {
        var companyIdString = (HttpContext.Items["companyId"]?.ToString()) ?? throw new Exception();
        var companyId = long.Parse(companyIdString);

        var product = _mapper.Map<Product>(createProductRequest);
        product.CompanyId = companyId;

        await _productService.CreateProduct(product);
    }

    [HttpPut]
    public async Task EditProduct(EditProductRequest editProductRequest)
    {
        var product = _mapper.Map<Product>(editProductRequest);

        await _productService.EditProduct(product);
    }

    [HttpGet]
    public async Task<GetAllProductsResponse> GetProducts([FromQuery] Pagination pagination)
    {
        var result = await _productService.GetProducts(pagination);
        return result;
    }

    [HttpGet("tolist")]
    public async Task<object> GetNamesAndIds()
    {
        var result = await _productService.GetNamesAndIds();
        return result;
    }

    [HttpDelete("{id}")]
    public async Task RemoveProduct(long id)
    {
        await _productService.RemoveProduct(id);
    }
}