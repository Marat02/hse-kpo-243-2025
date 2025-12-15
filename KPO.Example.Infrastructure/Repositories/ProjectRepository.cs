using KPO.Example.Models.Projects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace KPO.Example.Infrastructure.Repositories;

/// <summary>
/// Репозиторий - адаптер для класса проект
/// </summary>
public class ProjectRepository : IProjectRepository
{
    private readonly ExampleDbContext _dbContext;
    private readonly IDistributedCache _distributedCache;

    public ProjectRepository(ExampleDbContext dbContext, IDistributedCache distributedCache)
    {
        _dbContext = dbContext;
        _distributedCache = distributedCache;
    }

    public async Task<ProjectDao[]> GetAll(CancellationToken cancellation)
    {
        return await _dbContext.Projects.ToArrayAsync(cancellation);
    }

    public async Task<ProjectDao?> GetProjectDao(Guid id, CancellationToken cancellation)
    {
        return await _dbContext.Projects.FirstOrDefaultAsync(x => x.Id == id, cancellation);
    }

    public Task AddProject(ProjectDao project, CancellationToken cancellation)
    {
        _dbContext.Projects.Add(project);
        _distributedCache.Remove("project_count");
        return Task.CompletedTask;
    }

    public Task UpdateProject(ProjectDao dao, CancellationToken cancellation)
    {
        _dbContext.Projects.Update(dao);
        return Task.CompletedTask;
    }

    public async Task<int> CountAll(CancellationToken cancellation)
    {
        var count = await _distributedCache.GetStringAsync("project_count", cancellation);
        if (count is not null)
            return int.Parse(count);

        var countResult = await _dbContext.Projects.CountAsync(cancellation);

        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
        };

        await _distributedCache.SetStringAsync("project_count", countResult.ToString(), options, cancellation);
        return countResult;
    }

    public async Task Remove(ProjectDao project, CancellationToken cancellation)
    {
        _dbContext.Projects.Remove(project);
        await _distributedCache.RemoveAsync("project_count", cancellation);
    }
}