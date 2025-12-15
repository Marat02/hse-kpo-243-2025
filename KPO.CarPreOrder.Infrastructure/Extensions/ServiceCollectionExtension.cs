using KPO.CarPreOrder.Application.Handlers;
using KPO.CarPreOrder.Application.Repositories;
using KPO.CarPreOrder.Infrastructure.Repositories;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KPO.CarPreOrder.Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddCarPreOrderInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICarModelRepository, CarModelRepository>();
        services.AddNpgsql<CarPreOrderDbContext>(configuration["CarPreOrderPostgresConnectionStrings"]);
        
        return services;
    }
}