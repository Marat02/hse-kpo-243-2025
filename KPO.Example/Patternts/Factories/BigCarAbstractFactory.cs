using KPO.Example.Models.Blueprints;
using KPO.Example.Models.Cars;

namespace KPO.Example.Patternts.Factories;

public class BigCarAbstractFactory : IAbstractFactory
{
    private readonly int _carId;
    private readonly int _blueprintId;
    private readonly int _carWeigth;
    private readonly int _carHeight;
    private readonly int _carLength;

    public BigCarAbstractFactory(int carId, int blueprintId, int carWeigth, int carHeight, int carLength)
    {
        _carId = carId;
        _blueprintId = blueprintId;
        _carWeigth = carWeigth;
        _carHeight = carHeight;
        _carLength = carLength;
    }

    public ICar BuildCar()
    {
        return new BigCar(_carId, _blueprintId, _carWeigth, _carHeight, _carLength);
    }

    public IBlueprint BuildBlueprint()
    {
        return new BigBlueprint(_blueprintId, _carWeigth, _carHeight, _carLength);
    }
}