using DG.DAL.Entities;

using Microsoft.EntityFrameworkCore;

namespace DG.DAL.Context;

public class DatabaseContext : DbContext
{
    public DbSet<DrawingEntity> Drawings { get; set; } = null!;
    public DbSet<DrawingDescriptionEntity> DrawingDescriptions { get; set; } = null!;

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        if (base.Database.IsRelational())
        {
            base.Database.Migrate();
        }
    }
}