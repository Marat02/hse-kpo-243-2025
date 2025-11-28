using KPO.Example.Infrastructure.Repositories;
using KPO.Example.Models.Projects;
using KPO.Example.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace KPO.Example.Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddCarDevelopmentInfrastructure(
        this IServiceCollection services,
        string connectionString)
    {
        services.AddNpgsql<ExampleDbContext>(connectionString);
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}