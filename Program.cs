using ComplexTypeBug;
using ComplexTypeBug.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PhenX.EntityFrameworkCore.BulkInsert.Extensions;
using PhenX.EntityFrameworkCore.BulkInsert.Options;
using PhenX.EntityFrameworkCore.BulkInsert.PostgreSql;

var services = new ServiceCollection()
    .AddDbContext<ComplexTypeBugDbContext>(builder =>
    {
        builder.LogTo(Console.WriteLine, LogLevel.Information);
        builder.EnableSensitiveDataLogging();
        builder.UseBulkInsertPostgreSql();
        builder.UseNpgsql(
            "Server=localhost;Database=testdb;User Id=postgres;Password=admin;Include Error Detail = true");
    }).BuildServiceProvider();

var tableWithComplexTypeData = new TableWithSmartEnum
{
    Enum = TestEnum.Value
};

var dbContext = services.GetRequiredService<ComplexTypeBugDbContext>();

// insert okey
await dbContext.ExecuteBulkInsertAsync([tableWithComplexTypeData], onConflict: new OnConflictOptions<TableWithSmartEnum>
{
});


Console.ReadLine();