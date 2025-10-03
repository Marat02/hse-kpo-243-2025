using KPO.Example.Utils;

namespace KPO.Example.Models;

public class Project
{
    public string Name { get; private set; }

    public string Target { get; private set; }

    private List<Car> _cars = [];

    private List<Blueprint> _blueprints = [];

    private List<ITest> _tests = [];

    public IReadOnlyCollection<Car> Cars => _cars;
    public IReadOnlyCollection<Blueprint> Blueprints => _blueprints;

    public IReadOnlyCollection<ITest> Tests => _tests;

    public Project(string name, string target)
    {
        Name = name;
        Target = target;
    }
    
    public void SetName(string name)
    {
        Name = name;
    }

    public void AddTest(ITest test)
    {
        _tests.Add(test);
    }
    
    public bool ExecuteTests()
    {
        return _tests.All(test => test.Execute());
    }
}