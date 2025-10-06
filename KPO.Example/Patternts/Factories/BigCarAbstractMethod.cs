using KPO.Example.Models.Blueprints;
using KPO.Example.Models.Cars;

namespace KPO.Example.Patternts.Factories;

public class BigCarAbstractMethod : ICarAbstractMethod
{
    private readonly int _id;

    public BigCarAbstractMethod(int id)
    {
        _id = id;
    }

    public ICar? Build(IBlueprint blueprint)
    {
        if (blueprint is not BigBlueprint bigBlueprint)
        {
            return null;
        }
        
        return new BigCar(_id, bigBlueprint.Id, bigBlueprint.CarWeigth, bigBlueprint.CarHeight, bigBlueprint.CarLength);
    }
}