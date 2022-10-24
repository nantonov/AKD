using DG.BLL.Services;
using DG.BLL.Services.Contract;

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

        return services;
    }
}