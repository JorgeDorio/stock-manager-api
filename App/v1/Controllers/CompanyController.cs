using App.v1.DTOs.Company.Create;
using App.v1.DTOs.Company.Edit;
using App.v1.DTOs.Company.GetAll;
using App.v1.Models;
using App.v1.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.v1.Controllers;

[Route("v1/[controller]")]
[ApiController]
public class CompanyController(IMapper mapper, CompanyService companyService) : ControllerBase
{
    private readonly IMapper _mapper = mapper;
    private readonly CompanyService _companyService = companyService;

    [HttpPost]
    public async Task<CreateCompanyResponse> CreateCompany(CreateCompanyRequest createCompanyRequest)
    {
        var company = _mapper.Map<Company>(createCompanyRequest);

        var result = await _companyService.CreateCompany(company);

        return _mapper.Map<CreateCompanyResponse>(result);
    }

    [HttpPut]
    public async Task EditCompany(EditCompanyRequest editCompanyRequest)
    {
        var company = _mapper.Map<Company>(editCompanyRequest);

        await _companyService.EditCompany(company);
    }

    [HttpGet]
    public async Task<GetAllCompaniesResponse> GetCompanies([FromQuery] Pagination pagination)
    {
        var result = await _companyService.GetCompanies(pagination);
        return result;
    }

    [HttpGet("tolist")]
    public async Task<object> GetNamesAndIds(){
        var result = await _companyService.GetNamesAndIds();
        return result;
    }

    [HttpDelete("{id}")]
    public async Task RemoveCompany(long id)
    {
        await _companyService.RemoveCompany(id);
    }
}