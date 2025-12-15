using KPO.Example.Models.Entities;

namespace KPO.Example.Utils;

public interface IEntityCountRepository
{
    Task<EntityCount?> Get(string name, CancellationToken cancellation);
    
    Task Update(EntityCount entityCount, CancellationToken cancellation);
    
    Task Add(EntityCount entityCount, CancellationToken cancellation);
}