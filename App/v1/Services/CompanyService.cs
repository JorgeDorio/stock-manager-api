using App.v1.Context;
using App.v1.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.v1.Services;

public class CompanyService(StockContext context)
{
    private readonly StockContext _context = context;

    public async Task<Company> CreateCompany(Company company)
    {
        var db = await _context.Companies.AddAsync(company);
        await _context.SaveChangesAsync();

        return db.Entity;
    }

    public async Task EditCompany(Company company)
    {
        var db = await _context.Companies.FirstOrDefaultAsync(c => c.Id == company.Id);

        if (db != null)
        {
            db.Cnpj = company.Cnpj;
            db.TradeName = company.TradeName;
            db.LegalName = company.LegalName;
            db.IsActive = company.IsActive;

            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Company>> GetCompanies()
    {
        var companies = await _context.Companies.ToListAsync();
        return companies;
    }

    public async Task RemoveCompany(long id)
    {
        var company = await _context.Companies.FindAsync(id);

        if (company != null)
        {
            _context.Companies.Remove(company);

            await _context.SaveChangesAsync();
        }
    }
}