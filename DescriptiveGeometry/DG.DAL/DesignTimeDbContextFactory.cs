using DG.DAL.Context;

using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DG.DAL;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DrawingContext>
{
    public DrawingContext CreateDbContext(params string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<DrawingContext>();
        optionsBuilder.UseSqlServer(
            configuration.GetConnectionString("DescriptiveGeometryDb"));

        return new DrawingContext(optionsBuilder.Options);
    }
}