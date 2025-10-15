using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ComplexTypeBug;

public class ComplexTypeBugDbContextFactory : IDesignTimeDbContextFactory<ComplexTypeBugDbContext>
{
    public ComplexTypeBugDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ComplexTypeBugDbContext>();
        optionsBuilder.UseNpgsql("Server=localhost;Database=testdb;User Id=postgres;Password=admin;Include Error Detail = true");

        return new ComplexTypeBugDbContext(optionsBuilder.Options);
    }
}