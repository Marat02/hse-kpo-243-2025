using Amazon.Runtime;
using Amazon.S3;
using KPO.Example.Application.Repositories;
using KPO.Example.Infrastructure.Repositories;
using KPO.Example.Models.Projects;
using KPO.Example.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KPO.Example.Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddCarDevelopmentInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration,
        string connectionString)
    {
        services.AddNpgsql<ExampleDbContext>(connectionString);
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<ICarEventRepository, CarEventRepository>();

        services.AddScoped<UnitOfWork>();
        services.AddScoped<IUnitOfWork>(t => t.GetRequiredService<UnitOfWork>());
        services.AddScoped<IEventBus>(t => t.GetRequiredService<UnitOfWork>());
        
        services.AddScoped<IFileRepository, FileRepository>();
        services.AddScoped<IAmazonS3>(t =>
            new AmazonS3Client(new BasicAWSCredentials(
                    configuration["S3:AccessKey"], 
                    configuration["S3:SecretKey"]), 
                new AmazonS3Config
                {
                    ServiceURL = configuration["S3:Endpoint"],
                    ForcePathStyle = true
                }));
        return services;
    }
}