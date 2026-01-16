using ComplexTypeBug.Models;
using Microsoft.EntityFrameworkCore;

namespace ComplexTypeBug;

public class ComplexTypeBugDbContext : DbContext
{
    public ComplexTypeBugDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<TestTable> TestTables { get; set; }
    public DbSet<AnotherTestTable> AnotherTestTables { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TestTable>().HasKey(table => new { table.Key, table.Date });
        modelBuilder.Entity<TestTable>().ComplexProperty(table => table.ComplexObject);
        modelBuilder.Entity<AnotherTestTable>().ComplexProperty(table => table.ComplexProperty);
    }
}