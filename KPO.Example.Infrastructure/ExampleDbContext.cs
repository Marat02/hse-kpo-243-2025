using KPO.Example.Models.Projects;
using Microsoft.EntityFrameworkCore;

namespace KPO.Example.Infrastructure;

public class ExampleDbContext : DbContext
{
    public DbSet<ProjectDao> Projects { get; set; }
    
    public ExampleDbContext(DbContextOptions<ExampleDbContext> options) : base(options)
    {
    }
}