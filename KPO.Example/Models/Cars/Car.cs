namespace KPO.Example.Models.Cars;

public class Car : ICar
{
    public Car(int id, int blueprintId)
    {
        Id = id;
        BlueprintId = blueprintId;
    }

    public int Id { get; }

    public int BlueprintId { get; }
}