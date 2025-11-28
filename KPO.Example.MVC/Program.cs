using KPO.Example.Application.Extensions;
using KPO.Example.Application.Services;
using KPO.Example.Infrastructure.Extensions;
using KPO.Example.Infrastructure.Repositories;
using KPO.Example.Models.Projects;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddMediatR(t => t.RegisterServicesFromAssembly(typeof(ProjectService).Assembly));
builder.Services.AddCarDevelopmentApplication();
builder.Services.AddCarDevelopmentInfrastructure(builder.Configuration["PostgresConnectionStrings"]);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();