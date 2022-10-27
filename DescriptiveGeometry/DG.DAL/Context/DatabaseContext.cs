using DG.DAL.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DG.DAL.Context;

public class DatabaseContext : DbContext
{
    public DbSet<DrawingEntity> Drawings { get; set; }
    public DbSet<DrawingDescriptionEntity> DrawingDescriptions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        
        optionsBuilder.UseSqlServer(
            configuration.GetConnectionString("DescriptiveGeometryDb"));
    }
}