using KPO.Example.Models.Cars;

namespace KPO.Example.Patternts.Builder;

public class BigCarDirector : IBigCarDirector
{
    private IBigCarBuilder _builder;

    public BigCarDirector(IBigCarBuilder builder)
    {
        _builder = builder;
    }

    public ICar BuildCar()
    {
        _builder.SetCarLength(1000);
        _builder.SetId(1);
        _builder.SetBlueprintId(2);
        _builder.SetCarHeight(4);
        _builder.SetCarWeigth(500);

        return _builder.Build();
    }
}