using KPO.Example.Application.Commands;
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
;        return project;
    }

    public async Task<ICar> CreateCar(Guid id, int blueprintId, string name, CancellationToken cancellation)
    {
        var projectDao = await _unitOfWork.ProjectRepository.GetProjectDao(id, cancellation);
        var project = new Project();
        project.FromDao(projectDao, _eventBus);

        project.BuildCar(blueprintId, name);
        var car = project.Cars.First();
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
}