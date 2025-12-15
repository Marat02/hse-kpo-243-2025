using KPO.Example.Models.Entities;
using KPO.Example.Utils;
using Microsoft.EntityFrameworkCore;

namespace KPO.Example.Infrastructure.Repositories;

public class ProcessedEventRepository : IProcessedEventRepository
{
    private readonly ExampleDbContext _dbContext;

    public ProcessedEventRepository(ExampleDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task AddAsync(ProcessedEvent processedEvent, CancellationToken cancellationToken)
    {
        _dbContext.Add(processedEvent);
        return Task.CompletedTask;
    }

    public Task<ProcessedEvent?> Get(Guid id, CancellationToken cancellationToken)
    {
        return _dbContext.ProcessedEvents.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
    }
}