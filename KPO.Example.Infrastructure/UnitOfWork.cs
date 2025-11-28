using KPO.Example.Models.Projects;
using KPO.Example.Utils;

namespace KPO.Example.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly ExampleDbContext _dbContext;

    public UnitOfWork(IProjectRepository projectRepository, ExampleDbContext dbContext)
    {
        ProjectRepository = projectRepository;
        _dbContext = dbContext;
    }

    public IProjectRepository ProjectRepository { get; }

    public async Task SaveChangesAsync(CancellationToken cancellation)
    {
        await _dbContext.SaveChangesAsync(cancellation);
    }
}