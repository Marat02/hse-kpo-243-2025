using KPO.Example.Application.Models;

namespace KPO.Example.Application.Repositories;

public interface ICarEventRepository
{
    Task<CarCreatedEvent[]> GetEvents(CancellationToken cancellation);
    
    Task SaveEvents(CancellationToken cancellation);
}