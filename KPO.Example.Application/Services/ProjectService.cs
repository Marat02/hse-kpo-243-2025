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

    public async Task<Project[]> GetAllProjects(CancellationToken cancellation)
    {
        var daos = await _projectRepository.GetAll(cancellation);
        return daos.Select(dao =>
        {
            var project = new Project();
            project.FromDao(dao);
            return project;
        }).ToArray();
    }

    public async Task<Project> CreateProject(string name, string target, CancellationToken cancellation)
    {
        var project = new CreateProjectCommand(name, target).Execute();
        await _projectRepository.AddProject(project.ToDao(), cancellation);
        return project;
    }

    public async Task<ICar> CreateCar(CancellationToken cancellation)
    {
        return await _mediator.Send(new CreateCarCommand(1, 1), cancellation);
    }
}