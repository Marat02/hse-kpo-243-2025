using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KPO.CarPreOrder.Infrastructure.Extensions;

public static class WebExtension 
{
    public static async Task StartCarPreOrder(this IServiceProvider provider)
    {
        using var scope = provider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<CarPreOrderDbContext>();
        await context.Database.MigrateAsync();
    }
}