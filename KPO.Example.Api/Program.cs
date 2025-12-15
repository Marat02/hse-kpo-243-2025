using Hangfire;
using Hangfire.PostgreSql;
using KPO.CarPreOrder.Application.Extensions;
using KPO.CarPreOrder.Application.Handlers;
using KPO.CarPreOrder.Infrastructure.Extensions;
using KPO.Example.Api.Websocket;
using KPO.Example.Application.Consumers;
using KPO.Example.Application.Extensions;
using KPO.Example.Application.Services;
using KPO.Example.Infrastructure.Extensions;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddHangfire(t => t.UsePostgreSqlStorage(builder.Configuration["PostgresConnectionStrings"]));
builder.Services.AddHangfireServer();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddMediatR(t => t.RegisterServicesFromAssemblies(typeof(ProjectService).Assembly, typeof(Program).Assembly));
builder.Services.AddCarPreOrderApplication();
builder.Services.AddCarDevelopmentApplication();
builder.Services.AddCarDevelopmentInfrastructure(builder.Configuration, builder.Configuration["PostgresConnectionStrings"]);
builder.Services.AddCarPreOrderInfrastructure(builder.Configuration);
builder.Services.AddSingleton<WebSocketConnectionManager>();

builder.Services.AddMassTransit(t =>
{
    t.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(builder.Configuration["RabbitMq:Host"], x =>
        {
            x.Username(builder.Configuration["RabbitMq:Username"]);
            x.Password(builder.Configuration["RabbitMq:Password"]);
        });
        cfg.ConfigureEndpoints(context);
    });

    t.AddConsumers(typeof(CarBuildEventHandler).Assembly, typeof(ProjectCreatedConsumer).Assembly);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseHangfireDashboard();
    app.MapOpenApi();
    app.UseSwaggerUI();
    app.UseSwagger();
}

app.UseWebSockets();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.Services.StartCarDevelopment();
await app.Services.StartCarPreOrder();

RecurringJob.AddOrUpdate<ICarEventService>("car-event-job", t => t.SendEvents(CancellationToken.None), Cron.Minutely);

app.Run();