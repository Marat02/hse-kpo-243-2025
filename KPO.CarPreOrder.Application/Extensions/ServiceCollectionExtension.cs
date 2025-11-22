using Microsoft.Extensions.DependencyInjection;

namespace KPO.CarPreOrder.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddCarPreOrderApplication(this IServiceCollection services)
    {
        services.AddMediatR(t => t.RegisterServicesFromAssembly(typeof(ServiceCollectionExtension).Assembly));
        return services;
    }
}