using KPO.Example.Models.Blueprints;
using KPO.Example.Models.Cars;

namespace KPO.Example.Patternts.Factories;

public class CarAbstractMethod : ICarAbstractMethod
{
    private readonly int _id;

    public CarAbstractMethod(int id)
    {
        _id = id;
    }

    public ICar? Build(IBlueprint blueprint)
    {
        return new Car(_id, blueprint.Id);
    }
}