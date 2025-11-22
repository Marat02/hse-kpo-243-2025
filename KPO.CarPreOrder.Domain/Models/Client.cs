using KPO.DDD.Basic;

namespace KPO.CarPreOrder.Domain.Models;

public class Client : IEntity
{
    public Guid Id { get; private set; }
    
    public string FirstName { get; private set; }
    
    public string LastName { get; private set; }
}