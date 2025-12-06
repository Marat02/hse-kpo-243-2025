using KPO.DDD.Basic;
using KPO.Example.Application.Models;
using KPO.Example.Contracts.Events;
using KPO.Example.Models.Projects;
using KPO.Example.Utils;

namespace KPO.Example.Infrastructure;

public class UnitOfWork : IUnitOfWork, IEventBus
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

    public void Publish<T>(T @event) where T : IEvent
    {
        if (@event is CarBuildEvent carBuildEvent)
        {
            _dbContext.CarCreatedEvents.Add(new CarCreatedEvent
            {
                Id = carBuildEvent.Id,
                Name = carBuildEvent.Name,
                Type = carBuildEvent.Type
            });
        }
    }
}