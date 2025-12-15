using KPO.Example.Models.Entities;

namespace KPO.Example.Utils;

public interface IProcessedEventRepository
{
    public Task AddAsync(ProcessedEvent processedEvent, CancellationToken cancellationToken);

    public Task<ProcessedEvent?> Get(Guid id, CancellationToken cancellationToken);
}