using KPO.Example.Models.Blueprints;
using KPO.Example.Models.Cars;
using KPO.Example.Models.Checks;

namespace KPO.Example.Models.Projects;

public record ProjectDao(
    string Name,
    string Target,
    IReadOnlyCollection<ICar> Cars,
    IReadOnlyCollection<IBlueprint> Blueprints = null,
    IReadOnlyCollection<ICheck> Checks = null);