using KPO.Example.Application.Commands;
using KPO.Example.Application.Mediators;
using KPO.Example.Models.Cars;
using KPO.Example.Models.Projects;
using IMediator = MediatR.IMediator;

namespace KPO.Example.Application.Services;

public class ProjectService : IProjectService
{
    private readonly IMediator _mediator;
    private readonly IProjectRepository _projectRepository;

    public ProjectService(IMediator mediator, IProjectRepository projectRepository)
    {
        _mediator = mediator;
        _projectRepository = projectRepository;
    }

    public Project[] GetAllProjects()
    {
        var daos = _projectRepository.GetAll();
        return daos.Select(dao =>
        {
            var project = new Project();
            project.FromDao(dao);
            return project;
        }).ToArray();
    }

    public Project CreateProject(string name, string target)
    {
        var project = new CreateProjectCommand(name, target).Execute();
        _projectRepository.SaveProject(project.ToDao());
        return project;
    }

    public ICar CreateCar()
    {
        return _mediator.Send(new CreateCarCommand(1, 1)).GetAwaiter().GetResult();
    }
}