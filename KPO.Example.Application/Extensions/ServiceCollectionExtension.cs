using KPO.Example.Application.Services;
using KPO.Example.Contracts.Events;
using Microsoft.Extensions.DependencyInjection;

namespace KPO.Example.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddCarDevelopmentApplication(this IServiceCollection services)
    {
        services.AddMediatR(t => 
            t.RegisterServicesFromAssemblies(
                typeof(ServiceCollectionExtension).Assembly,
                typeof(CarBuildEvent).Assembly));
        services.AddScoped<ICarEventService, CarEventService>();
        return services;
    }
}