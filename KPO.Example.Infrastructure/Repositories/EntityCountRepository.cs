using KPO.Example.Models.Entities;
using KPO.Example.Utils;
using Microsoft.EntityFrameworkCore;

namespace KPO.Example.Infrastructure.Repositories;

public class EntityCountRepository : IEntityCountRepository
{
    private readonly ExampleDbContext _dbContext;

    public EntityCountRepository(ExampleDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<EntityCount?> Get(string name, CancellationToken cancellation)
    {
        return await _dbContext.EntityCounts.FirstOrDefaultAsync(x => x.Name == name, cancellation);
    }

    public Task Update(EntityCount entityCount, CancellationToken cancellation)
    {
        _dbContext.EntityCounts.Update(entityCount);
        return Task.CompletedTask;
    }

    public Task Add(EntityCount entityCount, CancellationToken cancellation)
    {
        _dbContext.EntityCounts.Add(entityCount);
        return Task.CompletedTask;
    }
}