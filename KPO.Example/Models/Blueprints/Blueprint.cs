namespace KPO.Example.Models.Blueprints;

public class Blueprint : IBlueprint
{
    public Blueprint(int id)
    {
        Id = id;
    }

    public int Id { get; }
    public IBlueprint Clone()
    {
        return new Blueprint(Id);
    }
}