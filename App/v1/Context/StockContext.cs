using App.v1.Models;
using Microsoft.EntityFrameworkCore;

namespace App.v1.Context;

public class StockContext(DbContextOptions<StockContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Company> Companies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(u => u.Company)
            .WithMany(c => c.Users)
            .HasForeignKey(u => u.CompanyId);

        base.OnModelCreating(modelBuilder);
    }
}