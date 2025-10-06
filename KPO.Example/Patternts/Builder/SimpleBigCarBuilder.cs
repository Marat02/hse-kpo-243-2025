using KPO.Example.Models.Cars;

namespace KPO.Example.Patternts.Builder;

public class SimpleBigCarBuilder
{
    private int _id;
    private int _blueprintId;
    private int _carWeigth;
    private int _carHeight;
    private int _carLength;
    
    public SimpleBigCarBuilder SetId(int id)
    {
        _id = id;
        return this;
    }

    public SimpleBigCarBuilder SetBlueprintId(int blueprintId)
    {
        _blueprintId = blueprintId;
        return this;
    }

    public SimpleBigCarBuilder SetCarWeigth(int carWeigth)
    {
        _carWeigth = carWeigth;
        return this;
    }

    public SimpleBigCarBuilder SetCarHeight(int carHeight)
    {
        _carHeight = carHeight;
        return this;
    }

    public SimpleBigCarBuilder SetCarLength(int carLength)
    {
        _carLength = carLength;
        return this;
    }

    public BigCar Build()
    {
        return new BigCar(_id, _blueprintId, _carWeigth, _carHeight, _carLength);
    }
}