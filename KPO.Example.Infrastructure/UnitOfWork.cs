using KPO.DDD.Basic;
using KPO.Example.Application.Models;
using KPO.Example.Contracts.Events;
using KPO.Example.Models.Projects;
using KPO.Example.Utils;
using MassTransit;

namespace KPO.Example.Infrastructure;

public class UnitOfWork : IUnitOfWork, IEventBus
{
    private readonly ExampleDbContext _dbContext;
    private readonly IBus _bus;

    public UnitOfWork(IProjectRepository projectRepository, ExampleDbContext dbContext,
        IEntityCountRepository entityCountRepository, IBus bus, IProcessedEventRepository processedEventRepository)
    {
        ProjectRepository = projectRepository;
        _dbContext = dbContext;
        EntityCountRepository = entityCountRepository;
        _bus = bus;
        ProcessedEventRepository = processedEventRepository;
    }

    public IProjectRepository ProjectRepository { get; }

    public IEntityCountRepository EntityCountRepository { get; }

    public IProcessedEventRepository ProcessedEventRepository { get; set; }

    public async Task SaveChangesAsync(CancellationToken cancellation)
    {
        await _dbContext.SaveChangesAsync(cancellation);
    }

    public void Publish<T>(T @event) where T : IEvent
    {
        if (@event is ProjectCreatedEvent projectCreatedEvent)
            _bus.Publish(projectCreatedEvent);

        if (@event is ProjectDeletedEvent projectDeletedEvent)
            _bus.Publish(projectDeletedEvent);

        if (@event is CarBuildEvent carBuildEvent)
        {
            _dbContext.CarEvents.Add(new CarEventModel
            {
                Id = carBuildEvent.Id,
                Name = carBuildEvent.Name,
                Type = carBuildEvent.Type,
                IsSuccess = false
            });
        }
    }
}