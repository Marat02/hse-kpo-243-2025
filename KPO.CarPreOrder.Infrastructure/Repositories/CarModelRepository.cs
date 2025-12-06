using KPO.CarPreOrder.Application.Repositories;
using KPO.CarPreOrder.Domain.Models;

namespace KPO.CarPreOrder.Infrastructure.Repositories;

public class CarModelRepository : ICarModelRepository
{
    private readonly CarPreOrderDbContext _dbContext;

    public CarModelRepository(CarPreOrderDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(CarModel carModel, CancellationToken cancellation)
    {
        _dbContext.Cars.Add(carModel);
        await _dbContext.SaveChangesAsync(cancellation);
    }
}