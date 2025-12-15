using KPO.Example.Application.Models;
using KPO.Example.Models.Entities;
using KPO.Example.Models.Projects;
using Microsoft.EntityFrameworkCore;

namespace KPO.Example.Infrastructure;

public class ExampleDbContext : DbContext
{
    public DbSet<ProjectDao> Projects { get; set; }
    
    public DbSet<CarEventModel> CarEvents { get; set; }
    
    public DbSet<EntityCount> EntityCounts { get; set; }

    public DbSet<ProcessedEvent> ProcessedEvents { get; set; }

    public ExampleDbContext(DbContextOptions<ExampleDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EntityCount>().HasKey(t => t.Name);
    }
}