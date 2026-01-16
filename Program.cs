using System.Globalization;
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

var now = DateTime.UtcNow;
var tableWithComplexTypeData = new TestTable()
{
    Key = "1",
    Date = now,
    ComplexObject = new TestComplexObject
    {
        Property = "test",
        Property1 = 100
    }
};

var dbContext = services.GetRequiredService<ComplexTypeBugDbContext>();

// insert okey
await dbContext.ExecuteBulkInsertAsync([tableWithComplexTypeData], onConflict: new OnConflictOptions<TestTable>
{
    Match = table => new { table.Key, table.Date }
});

tableWithComplexTypeData.ComplexObject = new TestComplexObject
{
    Property = "changed",
    Property1 = 200
};

//not updated
await dbContext.ExecuteBulkInsertAsync([tableWithComplexTypeData], onConflict: new OnConflictOptions<TestTable>
{
    Match = table => new { table.Key, table.Date}
});

dbContext.ChangeTracker.Clear();

// result will have 
// Property = "test",
// Property1 = 100

var result = dbContext.TestTables.ToArray();

Console.ReadLine();