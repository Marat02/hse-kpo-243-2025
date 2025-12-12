using KPO.Example.Application.Models;
using KPO.Example.Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KPO.Example.Infrastructure.Repositories;

public class CarEventRepository : ICarEventRepository
{
    private readonly ExampleDbContext _dbContext;

    public CarEventRepository(ExampleDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CarEventModel[]> Get(CancellationToken cancellationToken)
    {
        return await _dbContext.CarEvents.Where(t => !t.IsSuccess).ToArrayAsync(cancellationToken);
    }

    public async Task Save(CancellationToken cancellationToken)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}