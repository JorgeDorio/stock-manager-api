using App.v1.Models;
using Microsoft.EntityFrameworkCore;

namespace App.v1.Context;

public class StockContext(DbContextOptions<StockContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Company> Companies { get; set; }
}