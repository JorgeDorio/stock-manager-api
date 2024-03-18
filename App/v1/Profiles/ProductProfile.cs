using App.v1.DTOs.Product.Create;
using App.v1.DTOs.Product.Edit;
using App.v1.Models;
using AutoMapper;

namespace App.v1.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductRequest, Product>();
        CreateMap<EditProductRequest, Product>();
    }
}