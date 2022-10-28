using DG.BLL.Interfaces;
using DG.BLL.Services;
using DG.DAL.DI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DG.BLL;

public static class Registration
{
    public static IServiceCollection AddDrawings(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IDrawingService, DrawingService>();
        services.AddDataContext(configuration);

        return services;
    }
}