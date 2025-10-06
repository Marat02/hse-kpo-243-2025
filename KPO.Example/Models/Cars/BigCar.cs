namespace KPO.Example.Models.Cars;

public class BigCar : ICar
{
    public BigCar(int id, int blueprintId, int weigth, int height, int length)
    {
        Id = id;
        BlueprintId = blueprintId;
        Weigth = weigth;
        Height = height;
        Length = length;
    }

    public int Id { get; }
    
    public int BlueprintId { get; }
    
    public int Weigth { get; }
    
    public int Height { get; }
    
    public int Length { get; }
}