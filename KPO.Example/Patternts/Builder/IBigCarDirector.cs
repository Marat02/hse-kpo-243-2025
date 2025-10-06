using KPO.Example.Models.Cars;

namespace KPO.Example.Patternts.Builder;

public interface IBigCarDirector
{
    public ICar BuildCar();
}