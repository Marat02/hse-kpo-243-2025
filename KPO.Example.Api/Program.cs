using KPO.CarPreOrder.Application.Extensions;
using KPO.CarPreOrder.Infrastructure.Extensions;
using KPO.Example.Api.Websocket;
using KPO.Example.Application.Extensions;
using KPO.Example.Application.Services;
using KPO.Example.Infrastructure.Extensions;
using KPO.Example.Infrastructure.Repositories;
using KPO.Example.Models.Projects;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddMediatR(t => t.RegisterServicesFromAssemblies(typeof(ProjectService).Assembly, typeof(Program).Assembly));
builder.Services.AddCarPreOrderApplication();
builder.Services.AddCarDevelopmentApplication();
builder.Services.AddCarDevelopmentInfrastructure(builder.Configuration["PostgresConnectionStrings"]);
builder.Services.AddCarPreOrderInfrastructure(builder.Configuration);
builder.Services.AddSingleton<WebSocketConnectionManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI();
    app.UseSwagger();
}

app.UseWebSockets();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.Services.StartCarDevelopment();

app.Run();