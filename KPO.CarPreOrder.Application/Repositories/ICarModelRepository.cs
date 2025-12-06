using KPO.CarPreOrder.Domain.Models;

namespace KPO.CarPreOrder.Application.Repositories;

public interface ICarModelRepository
{
    Task AddAsync(CarModel carModel, CancellationToken cancellation);
}