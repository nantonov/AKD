using Microsoft.EntityFrameworkCore.SqlServer.Migrations.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DG.DAL.Context;

internal class HistoryRepository : SqlServerHistoryRepository
{
    public HistoryRepository(HistoryRepositoryDependencies dependencies) : base(dependencies)
    {

    }

    protected override void ConfigureTable(EntityTypeBuilder<HistoryRow> history)
    {
        base.ConfigureTable(history);
        history.Property(h => h.MigrationId).HasColumnName("Id");
        history.Property(h => h.ProductVersion).HasColumnName("Version");
    }
}
