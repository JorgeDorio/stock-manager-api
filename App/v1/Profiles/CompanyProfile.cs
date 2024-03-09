using App.v1.DTOs.Company.Create;
using App.v1.DTOs.Company.Edit;
using App.v1.Models;
using AutoMapper;

namespace App.v1.Profiles;

public class CompanyProfile : Profile
{
    public CompanyProfile()
    {
        CreateMap<CreateCompanyRequest, Company>();
        CreateMap<Company, CreateCompanyResponse>();
        CreateMap<EditCompanyRequest, Company>();
    }
}