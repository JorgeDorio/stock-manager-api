using App.v1.Context;
using App.v1.DTOs.Product.GetAll;
using App.v1.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.v1.Services;

public class ProductService(StockContext context)
{
    private readonly StockContext _context = context;

    public async Task<Product> CreateProduct(Product product)
    {
        var db = await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();

        return db.Entity;
    }

    public async Task EditProduct(Product product)
    {
        var db = await _context.Products.FirstOrDefaultAsync(c => c.Id == product.Id);

        if (db != null)
        {
            db.Name = product.Name;
            db.Category = product.Category;
            db.Subcategory = product.Subcategory;
            db.Brand = product.Brand;
            db.Description = product.Description;

            await _context.SaveChangesAsync();
        }
    }

    public async Task<GetAllProductsResponse> GetProducts(Pagination pagination)
    {
        var query = _context.Products.AsQueryable();
        pagination.TotalItems = await query.CountAsync();

        var products = await query.OrderByDescending(c => c.Id).Skip(pagination.ItemsPerPage * (pagination.CurrentPage - 1)).Take(pagination.ItemsPerPage).ToListAsync();

        return new(products, pagination);
    }

    public async Task RemoveProduct(long id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product != null)
        {
            _context.Products.Remove(product);

            await _context.SaveChangesAsync();
        }
    }

    public async Task<object> GetNamesAndIds()
    {
        var products = await _context.Products.Select(e => new { e.Name, e.Id }).ToListAsync();

        return products;
    }
}