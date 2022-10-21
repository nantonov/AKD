using DG.BLL.Services;
using DG.BLL.Services.Contract;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DG.BLL;

public static class Registration
{
    public static IServiceCollection AddDrawings(
        this IServiceCollection services,
        IConfiguration configuration)
    {

        //var optionsBuilder = new DbContextOptionsBuilder<DrawingsContext>();
        //optionsBuilder.UseSqlServer(
        //    config.GetConnectionString("DescriptiveGeometryDb"),
        //    new MySqlServerVersion(new Version(8, 0, 25)));

        //services.AddDbContextPool<DrawingContext>(
        //    (s, b) =>
        //        b.UseNpgsql(configuration.GetConnectionString("DescriptiveGeometryDb")));

        services.AddScoped<IDrawingService, DrawingService>();

        return services;
    }
}