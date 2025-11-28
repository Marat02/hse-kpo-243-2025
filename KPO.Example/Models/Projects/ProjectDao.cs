using KPO.Example.Models.Blueprints;
using KPO.Example.Models.Cars;
using KPO.Example.Models.Checks;

namespace KPO.Example.Models.Projects;

public record ProjectDao
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Target { get; set; }
}