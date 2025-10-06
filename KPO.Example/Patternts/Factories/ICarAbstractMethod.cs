using KPO.Example.Models.Blueprints;
using KPO.Example.Models.Cars;

namespace KPO.Example.Patternts.Factories;

/// <summary>
/// Фабричный метод для автомобиля
/// </summary>
public interface ICarAbstractMethod
{
    public ICar? Build(IBlueprint blueprint);
}