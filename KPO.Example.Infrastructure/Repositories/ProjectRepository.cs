using KPO.Example.Models.Projects;
using Microsoft.EntityFrameworkCore;

namespace KPO.Example.Infrastructure.Repositories;

/// <summary>
/// Репозиторий - адаптер для класса проект
/// </summary>
public class ProjectRepository : IProjectRepository
{
    private readonly ExampleDbContext _dbContext;

    public ProjectRepository(ExampleDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ProjectDao[]> GetAll(CancellationToken cancellation)
    {
        return await _dbContext.Projects.ToArrayAsync(cancellation);
    }

    public async Task<ProjectDao?> GetProjectDao(Guid id, CancellationToken cancellation)
    {
        return await _dbContext.Projects.FirstOrDefaultAsync(x => x.Id == id, cancellation);
    }

    public async Task AddProject(ProjectDao project, CancellationToken cancellation)
    {
        _dbContext.Projects.Add(project);
    }
}