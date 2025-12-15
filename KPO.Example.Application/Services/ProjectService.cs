using KPO.Example.Application.Commands;
using KPO.Example.Contracts.Events;
using KPO.Example.Contracts.Views;
using KPO.Example.Models.Cars;
using KPO.Example.Models.Projects;
using KPO.Example.Utils;

namespace KPO.Example.Application.Services;

public class ProjectService : IProjectService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEventBus _eventBus;

    public ProjectService(IUnitOfWork unitOfWork, IEventBus eventBus)
    {
        _unitOfWork = unitOfWork;
        _eventBus = eventBus;
    }

    public async Task<Project[]> GetAllProjects(CancellationToken cancellation)
    {
        var daos = await _unitOfWork.ProjectRepository.GetAll(cancellation);
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
        await _unitOfWork.ProjectRepository.AddProject(project.ToDao(), cancellation);
        await _unitOfWork.SaveChangesAsync(cancellation);

        var projectCreatedEvent = new ProjectCreatedEvent(project.Id, project.Name, project.Target, Guid.NewGuid());
        _eventBus.Publish(projectCreatedEvent);
        return project;
    }

    public async Task<ICar> CreateCar(Guid id, int blueprintId, string name, CancellationToken cancellation)
    {
        var projectDao = await _unitOfWork.ProjectRepository.GetProjectDao(id, cancellation);
        var project = new Project();
        project.FromDao(projectDao, _eventBus);

        project.BuildCar(blueprintId, name);
        var car = project.Cars.First();
        await _unitOfWork.SaveChangesAsync(cancellation);
        return car;
    }

    public async Task<Project> Update(Guid id, string name, string target, CancellationToken cancellation)
    {
        var projectDao = await _unitOfWork.ProjectRepository.GetProjectDao(id, cancellation);
        var project = new Project();
        project.FromDao(projectDao, _eventBus);
        project.SetName(name);
        project.ToDao();
        await _unitOfWork.SaveChangesAsync(cancellation);
        return project;
    }

    public async Task<ProjectCountView> GetProjectCount(CancellationToken cancellation)
    {
        var count = await _unitOfWork.ProjectRepository.CountAll(cancellation);
        return new ProjectCountView(count);
    }

    public async Task DeleteProject(Guid id, CancellationToken cancellation)
    {
        var project = await _unitOfWork.ProjectRepository.GetProjectDao(id, cancellation);
        if (project is null)
            return;

        await _unitOfWork.ProjectRepository.Remove(project, cancellation);
        
        var projectDeletedEvent = new ProjectDeletedEvent(id, Guid.NewGuid());
        _eventBus.Publish(projectDeletedEvent);
        await _unitOfWork.SaveChangesAsync(cancellation);
    }
}