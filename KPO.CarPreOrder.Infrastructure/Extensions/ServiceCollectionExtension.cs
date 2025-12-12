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
        services.AddMassTransit(t =>
        {
            t.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(configuration["RabbitMq:Host"], x =>
                {
                    x.Username(configuration["RabbitMq:Username"]);
                    x.Password(configuration["RabbitMq:Password"]);
                });
                cfg.ConfigureEndpoints(context);
            });

            t.AddConsumers(typeof(CarBuildEventHandler).Assembly);
        });
        
        return services;
    }
}