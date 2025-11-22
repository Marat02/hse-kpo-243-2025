using KPO.DDD.Basic;

namespace KPO.CarPreOrder.Domain.Models;

public class CarModel : IEntity
{
    public CarModel(Guid id, int developmentId, string name, CarType carType)
    {
        Id = id;
        Name = name;
        CarType = carType;
        DevelopmentId = developmentId;
    }

    public Guid Id { get; private set; }
    
    public int DevelopmentId { get; private set; }
    
    public string Name { get; private set; }
    
    public CarType CarType { get; private set; }
}