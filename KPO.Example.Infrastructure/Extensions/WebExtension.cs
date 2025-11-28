using KPO.Example.Models.Projects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KPO.Example.Infrastructure.Extensions;

public static class WebExtension 
{
    public static async Task StartCarDevelopment(this IServiceProvider provider)
    {
        using var scope = provider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ExampleDbContext>();
        await context.Database.MigrateAsync();
    }
}