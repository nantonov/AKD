﻿using DG.DAL.Context;

using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DG.DAL;

public static class DependencyRegistrar
{
    public static IServiceCollection AddDrawingsContext(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
        optionsBuilder.UseSqlServer(
            configuration.GetConnectionString("DescriptiveGeometryDb"));

        return services;
    }
}