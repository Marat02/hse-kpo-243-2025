using KPO.Example.Application.Utils;
using KPO.Example.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace KPO.Example.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddCarDevelopmentApplication(this IServiceCollection services)
    {
        services.AddMediatR(t => t.RegisterServicesFromAssembly(typeof(ServiceCollectionExtension).Assembly));
        services.AddScoped<IEventBus, EventBus>();
        return services;
    }
}