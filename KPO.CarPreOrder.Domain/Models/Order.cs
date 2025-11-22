using KPO.DDD.Basic;

namespace KPO.CarPreOrder.Domain.Models;

public class Order : IAggregateRoot
{
    public Guid Id { get; private set; }
    
    public string Name { get; private set; }
    
    public Guid ClientId { get; private set; }
    
    public Guid Car { get; private set; }
    
    public Place Place { get; private set; }
}