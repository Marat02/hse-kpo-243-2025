using KPO.Example.Application.Models;

namespace KPO.Example.Application.Repositories;

public interface ICarEventRepository
{
    Task<CarEventModel[]> Get(CancellationToken cancellationToken);

    Task Save(CancellationToken cancellationToken);
}