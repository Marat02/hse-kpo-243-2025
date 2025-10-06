using KPO.Example.Models.Cars;

namespace KPO.Example.Patternts.Builder;

public class BigCarBuilder : IBigCarBuilder
{
    private int _id;
    private int _blueprintId;
    private int _carWeigth;
    private int _carHeight;
    private int _carLength;
    
    public void SetId(int id)
    {
        _id = id;
    }

    public void SetBlueprintId(int blueprintId)
    {
        _blueprintId = blueprintId;
    }

    public void SetCarWeigth(int carWeigth)
    {
        _carWeigth = carWeigth;
    }

    public void SetCarHeight(int carHeight)
    {
        _carHeight = carHeight;
    }

    public void SetCarLength(int carLength)
    {
        _carLength = carLength;
    }

    public ICar Build()
    {
        return new BigCar(_id, _blueprintId, _carWeigth, _carHeight, _carLength);
    }
}