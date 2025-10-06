namespace KPO.Example.Models.Blueprints;

public class BigBlueprint : IBlueprint
{
    public BigBlueprint(int id, int carWeigth, int carHeight, int carLength)
    {
        Id = id;
        CarWeigth = carWeigth;
        CarHeight = carHeight;
        CarLength = carLength;
    }

    public int Id { get; }
    
    public int CarWeigth { get; }
    
    public int CarHeight { get; }
    
    public int CarLength { get; }

    public IBlueprint Clone()
    {
        return new BigBlueprint(Id, CarWeigth, CarHeight, CarLength);
    }
}