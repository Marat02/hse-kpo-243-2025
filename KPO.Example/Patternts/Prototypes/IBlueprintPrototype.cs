using KPO.Example.Models.Blueprints;

namespace KPO.Example.Patternts.Prototypes;

public interface IBlueprintPrototype
{
    public IBlueprint Clone();
}