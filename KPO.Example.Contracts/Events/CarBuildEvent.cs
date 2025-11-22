using KPO.DDD.Basic;

namespace KPO.Example.Contracts.Events;

public class CarBuildEvent : IEvent
{
    public int Id { get; init; }
    
    public string Name { get; init; }
    
    public CarBuildType Type { get; init; }
}

public enum CarBuildType
{
    Car = 0,
    BigCar = 1
}