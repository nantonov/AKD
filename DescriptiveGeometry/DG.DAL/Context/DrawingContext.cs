using DG.DAL.Context.Entities;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace DG.DAL.Context;

public class DrawingContext : DbContext
{
    public DbSet<DrawingRow> Drawings { get; set; } = null!;
    public DbSet<DrawingDescriptionRow> DrawingDescription { get; set; } = null!;

    public DrawingContext(DbContextOptions<DrawingContext> options)
        : base(options)
    {
        //Database.EnsureDeleted();
        //Database.EnsureCreated();
    }

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
}