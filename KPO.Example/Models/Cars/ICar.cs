using KPO.Example.Models.Strategies;

namespace KPO.Example.Models.Cars;

public interface ICar : ICarStrategy
{
    public int Id { get; }

    public int BlueprintId { get; }
}