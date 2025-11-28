using KPO.Example.Contracts.Events;
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
    
    private IEventBus? _eventBus;

    private ProjectDao? _dao;

    public Project()
    {
    }

    public Project(string name, string target)
    {
        Id = Guid.NewGuid();
        Name = name;
        Target = target;
        Status = ProjectStatus.Draft;
        State = new DraftProjectState();
    }

    public Project(IProjectRepository projectRepository, IEventBus eventBus)
    {
        _projectRepository = projectRepository;
        _eventBus = eventBus;
    }

    public async Task Load(Guid id, CancellationToken cancellation)
    {
        var projectDao = await _projectRepository.GetProjectDao(id, cancellation);
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

    public bool BuildCar(int blueprintId, string name, ICarAbstractMethod? carAbstractMethod = null)
    {
        var blueprint = _blueprints.FirstOrDefault(b => b.Id == blueprintId);

        var car = carAbstractMethod?.Build(blueprint) ?? new Car(_cars.Count + 1, blueprintId);

        _cars.Add(car);
        _eventBus?.Publish(new CarBuildEvent
        {
            Id = car.Id,
            Name = name,
            Type = car is BigCar ? CarBuildType.BigCar : CarBuildType.Car
        });
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
        _dao ??= new ProjectDao();
        _dao.Name = Name;
        _dao.Id = Id;
        _dao.Target = Target;
        return _dao;
    }

    public void FromDao(ProjectDao dao, IEventBus? eventBus = null)
    {
        Id = dao.Id;
        Name = dao.Name;
        Target = dao.Target;
        _dao = dao;
        _eventBus = eventBus;
    }
}