using KPO.Example.Models.Blueprints;
using KPO.Example.Models.Cars;
using KPO.Example.Models.Checks;
using KPO.Example.Patternts.Factories;

namespace KPO.Example.Models;

public class Project
{
    public string Name { get; private set; }

    public string Target { get; private set; }

    private List<ICar> _cars = [];

    private List<IBlueprint> _blueprints = [];

    private List<ICheck> _checks = [];

    public IReadOnlyCollection<ICar> Cars => _cars;
    public IReadOnlyCollection<IBlueprint> Blueprints => _blueprints;

    public IReadOnlyCollection<ICheck> Checks => _checks;

    private static readonly ICar ReferenceCar = new Car(1, 1);

    public Project(string name, string target)
    {
        Name = name;
        Target = target;
    }

    public ICar GetReferenceCar()
    {
        return ReferenceCar;
    }

    public void SetName(string name)
    {
        Name = name;
    }

    public bool AddCheck(ICheck check)
    {
        if (_checks.Contains(check))
            return false;

        _checks.Add(check);
        return true;
    }

    public bool AddBlueprint(IBlueprint blueprint)
    {
        if (_blueprints.Contains(blueprint))
            return false;

        _blueprints.Add(blueprint);
        return true;
    }

    public bool BuildCar(int blueprintId, ICarAbstractMethod carAbstractMethod)
    {
        var blueprint = _blueprints.FirstOrDefault(b => b.Id == blueprintId);
        if (blueprint == null)
            return false;

        var car = carAbstractMethod.Build(blueprint);
        
        if (car == null)
            return false;
        
        _cars.Add(car);
        return true;
    }

    public bool ExecuteChecks()
    {
        return _checks.All(test => test.Execute());
    }
}