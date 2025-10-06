using KPO.Example.Patternts.Prototypes;

namespace KPO.Example.Models.Blueprints;

public interface IBlueprint : IBlueprintPrototype
{
    public int Id { get; }
}