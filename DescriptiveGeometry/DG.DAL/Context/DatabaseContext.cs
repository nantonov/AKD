using DG.DAL.Entities;

using Microsoft.EntityFrameworkCore;

namespace DG.DAL.Context;

public class DatabaseContext : DbContext
{
    public DbSet<DrawingEntity> Drawings { get; set; }
    public DbSet<DrawingDescriptionEntity> DrawingDescriptions { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        Database.Migrate();
    }
}