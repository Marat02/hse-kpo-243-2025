using KPO.Example.Models.Blueprints;
using KPO.Example.Models.Cars;
using KPO.Example.Models.Checks;

namespace KPO.Example.Models.Projects;

public record ProjectDao(
    Guid Id,
    string Name,
    string Target,
    IReadOnlyCollection<ICar> Cars,
    IReadOnlyCollection<IBlueprint> Blueprints,
    IReadOnlyCollection<ICheck> Checks);