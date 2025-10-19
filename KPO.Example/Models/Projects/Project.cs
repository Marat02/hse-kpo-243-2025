using KPO.Example.Models.Blueprints;
using KPO.Example.Models.Cars;
using KPO.Example.Models.Checks;
using KPO.Example.Models.States;
using KPO.Example.Models.Visitors;
using KPO.Example.Patternts.Factories;
using KPO.Example.Utils;

namespace KPO.Example.Models.Projects;

public class Project
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public string Target { get; private set; }

    public IReadOnlyCollection<ICar> Cars => _cars;
    public IReadOnlyCollection<IBlueprint> Blueprints => _blueprints;

    public IReadOnlyCollection<ICheck> Checks => _checks;

    public ProjectStatus Status { get; private set; }

    public IProjectState State { get; private set; }

    private static readonly ICar ReferenceCar = new Car(1, 1);

    private List<ICar> _cars = [];

    private List<IBlueprint> _blueprints = [];

    private List<ICheck> _checks = [];

    private IProjectRepository _projectRepository;

    public Project(string name, string target)
    {
        Name = name;
        Target = target;
        Status = ProjectStatus.Draft;
        State = new DraftProjectState();
    }

    public Project(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public void Load(Guid id)
    {
        var projectDao = _projectRepository.GetProjectDao(id);
        if (projectDao != null)
            FromDao(projectDao);
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

    public void SendToVerification()
    {
        State = State.SendToVerification();
    }

    public bool ExecuteChecks()
    {
        var visitor = new LogCheckVisitor();
        foreach (var check in _checks)
        {
            check.Accept(visitor);
        }

        var result = _checks.All(test => test.Execute());
        if (result)
            State = State.SetOnWork();
        return result;
    }

    public void Archive()
    {
        State = State.Archive();
    }

    public void Pause()
    {
        if (Status == ProjectStatus.OnWork)
            Status = ProjectStatus.OnPause;
    }
    
    public ProjectDao ToDao()
    {
        return new ProjectDao(Id, Name, Target, Cars.ToArray(), Blueprints.ToArray(), Checks.ToArray());
    }

    public void FromDao(ProjectDao dao)
    {
        Id = dao.Id;
        Name = dao.Name;
        Target = dao.Target;
        _cars = dao.Cars.ToList();
        _blueprints = dao.Blueprints.ToList();
        _checks = dao.Checks.ToList();
    }
}