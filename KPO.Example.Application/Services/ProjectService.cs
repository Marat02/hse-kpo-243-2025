using KPO.Example.Application.Commands;
using KPO.Example.Application.Mediators;
using KPO.Example.Models.Cars;
using KPO.Example.Models.Projects;
using IMediator = MediatR.IMediator;

namespace KPO.Example.Application.Services;

public class ProjectService : IProjectService
{
    private readonly IMediator _mediator;

    public ProjectService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public Project CreateProject(string name, string target)
    {
        return new CreateProjectCommand(name, target).Execute();
    }

    public ICar CreateCar()
    {
        return _mediator.Send(new CreateCarCommand(1, 1)).GetAwaiter().GetResult();
    }
}