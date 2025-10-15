using ComplexTypeBug.Models;
using Microsoft.EntityFrameworkCore;
using SmartEnum.EFCore;

namespace ComplexTypeBug;

public class ComplexTypeBugDbContext : DbContext
{
    public ComplexTypeBugDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<TableWithSmartEnum> TableWithComplexType { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureSmartEnum();
    }
}