using KPO.Example.Utils;

namespace KPO.Example.Models;

public class Project
{
    public string Name { get; private set; }

    public string Target { get; private set; }

    private List<Car> _cars = [];

    private List<Blueprint> _blueprints = [];

    private List<Test> _tests = [];

    public IReadOnlyCollection<Car> Cars => _cars;
    public IReadOnlyCollection<Blueprint> Blueprints => _blueprints;

    public IReadOnlyCollection<Test> Tests => _tests;

    public Project(Car car)
    {
        _cars.Add(car);
    }

    public Project()
    {
        _cars.Add(ServiceLocator.Resolve<Car>());
    }
    
    public void SetName(string name)
    {
        Name = name;
    }

    public void AddTest(Test test)
    {
        _tests.Add(test);
    }
}