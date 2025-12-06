using KPO.Example.Application.Models;
using KPO.Example.Application.Repositories;
using KPO.Example.Contracts.Events;
using Microsoft.EntityFrameworkCore;

namespace KPO.Example.Infrastructure.Repositories;

public class CarEventRepository : ICarEventRepository
{
    private readonly ExampleDbContext _dbContext;

    public CarEventRepository(ExampleDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CarCreatedEvent[]> GetEvents(CancellationToken cancellation)
    {
        var events = await _dbContext.CarCreatedEvents.Where(x => x.IsCompleted == false).ToArrayAsync(cancellation);
        return events;
    }

    public async Task SaveEvents(CancellationToken cancellation)
    {
        await _dbContext.SaveChangesAsync(cancellation);
    }
}