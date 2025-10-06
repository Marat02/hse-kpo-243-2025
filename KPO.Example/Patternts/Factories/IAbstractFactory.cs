using KPO.Example.Models.Blueprints;
using KPO.Example.Models.Cars;

namespace KPO.Example.Patternts.Factories;

/// <summary>
/// Абстрактная фабрика для автомобиля
/// </summary>
public interface IAbstractFactory
{
    public ICar BuildCar();
    
    public IBlueprint BuildBlueprint();
}