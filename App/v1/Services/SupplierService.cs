using App.v1.Context;
using App.v1.DTOs.Supplier.GetAll;
using App.v1.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.v1.Services;

public class SupplierService(StockContext context)
{
    private readonly StockContext _context = context;

    public async Task<Supplier> CreateSupplier(Supplier supplier)
    {
        var db = await _context.Suppliers.AddAsync(supplier);
        await _context.SaveChangesAsync();

        return db.Entity;
    }

    public async Task EditSupplier(Supplier supplier)
    {
        var db = await _context.Suppliers.FirstOrDefaultAsync(c => c.Id == supplier.Id);

        if (db != null)
        {
            db.Cnpj = supplier.Cnpj;
            db.TradeName = supplier.TradeName;
            db.LegalName = supplier.LegalName;

            await _context.SaveChangesAsync();
        }
    }

    public async Task<GetAllSuppliersResponse> GetSuppliers(Pagination pagination)
    {
        var query = _context.Suppliers.AsQueryable();
        pagination.TotalItems = await query.CountAsync();

        var suppliers = await query.OrderByDescending(c => c.Id).Skip(pagination.ItemsPerPage * (pagination.CurrentPage - 1)).Take(pagination.ItemsPerPage).ToListAsync();

        return new(suppliers, pagination);
    }

    public async Task RemoveSupplier(long id)
    {
        var supplier = await _context.Suppliers.FindAsync(id);

        if (supplier != null)
        {
            _context.Suppliers.Remove(supplier);

            await _context.SaveChangesAsync();
        }
    }

    public async Task<object> GetNamesAndIds()
    {
        var suppliers = await _context.Suppliers.Select(e => new { e.TradeName, e.Id }).ToListAsync();

        return suppliers;
    }
}