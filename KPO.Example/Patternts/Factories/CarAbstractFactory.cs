using KPO.Example.Models.Blueprints;
using KPO.Example.Models.Cars;

namespace KPO.Example.Patternts.Factories;

public class CarAbstractFactory : IAbstractFactory
{
    private readonly int _carId;
    private readonly int _blueprintId;

    public CarAbstractFactory(int carId, int blueprintId)
    {
        _carId = carId;
        _blueprintId = blueprintId;
    }

    public ICar BuildCar()
    {
        return new Car(_carId, _blueprintId);
    }

    public IBlueprint BuildBlueprint()
    {
        return new Blueprint(_blueprintId);
    }
}