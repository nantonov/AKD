using DG.DAL.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DG.DAL.Context;

public class DatabaseContext : DbContext
{
    public DbSet<DrawingRow> Drawings { get; set; }
    public DbSet<DrawingDescriptionRow> DrawingDescription { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        
        optionsBuilder.UseSqlServer(
            configuration.GetConnectionString("DescriptiveGeometryDb"));
    }
}