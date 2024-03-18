using App.v1.DTOs.Supplier.Create;
using App.v1.DTOs.Supplier.Edit;
using App.v1.Models;
using AutoMapper;

namespace App.v1.Profiles;

public class SupplierProfile : Profile
{
    public SupplierProfile()
    {
        CreateMap<CreateSupplierRequest, Supplier>();
        CreateMap<Supplier, CreateSupplierResponse>();
        CreateMap<EditSupplierRequest, Supplier>();
    }
}