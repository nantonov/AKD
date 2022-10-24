using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Shared.Core.DbMigration.Contracts;

public interface IDatabaseMigrationService<in TContext>
    where TContext : DbContext
{
    Task Migrate(
        string[] args,
        IDesignTimeDbContextFactory<TContext> factory,
        CancellationToken cancellationToken = default);
}