using DG.DAL.Context.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DG.DAL.Context;

public class DrawingContext : DbContext
{
    public DbSet<DrawingRow> Drawings { get; set; } = null!;
    public DbSet<DrawingDescriptionRow> DrawingDescription { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<DrawingRow>()
            .HasOne(d => d.Description)
            .WithOne(dd => dd.Drawing)
            .HasForeignKey<DrawingDescriptionRow>(dd => dd.Id);
        modelBuilder.Entity<DrawingRow>().ToTable("Drawings");
        modelBuilder.Entity<DrawingDescriptionRow>().ToTable("Drawings");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        
        optionsBuilder.UseSqlServer(
            configuration.GetConnectionString("DescriptiveGeometryDb"));
    }
}