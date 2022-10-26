using DG.BLL.AutoMapper;
using DG.BLL.Interfaces;
using DG.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DG.BLL;

public static class DependencyRegistrar
{
    public static IServiceCollection AddDrawings(
        this IServiceCollection services)
    {
        services.AddScoped<IDrawingService, DrawingService>();

        return services;
    }

    public static IServiceCollection AddAutoMapper(
        this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));

        return services;
    }
}