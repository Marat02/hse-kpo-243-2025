namespace KPO.Example.Models.Cars;

public class BigCar : BaseCar
{
    public BigCar(int id, int blueprintId, int weigth, int height, int length) : base(id, blueprintId)
    {
        Weigth = weigth;
        Height = height;
        Length = length;
    }

    public int Weigth { get; }
    
    public int Height { get; }
    
    public int Length { get; }
    
    public override string Serialize()
    {
        return $"BigCar: {Id}, {BlueprintId}, {Weigth}, {Height}, {Length}";
    }
}