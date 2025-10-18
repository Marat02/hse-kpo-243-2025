namespace KPO.Example.Models.Cars;

public abstract class BaseCar : ICar
{
    protected BaseCar(int id, int blueprintId)
    {
        Id = id;
        BlueprintId = blueprintId;
    }

    public virtual string Serialize()
    {
        return $"Car: {Id}, {BlueprintId}";
    }

    public int Id { get; }
    public int BlueprintId { get; }
}