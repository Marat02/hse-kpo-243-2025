using KPO.Example.Models.Projects;

namespace KPO.Example.Infrastructure.Repositories;

/// <summary>
/// Паттерн посредник для репозитория
/// </summary>
public class ProjectRepositoryProxy : IProjectRepository
{
    private IProjectRepository? _projectRepository;
    private readonly IReadOnlyCollection<ProjectDao> projects;

    public ProjectRepositoryProxy(IReadOnlyCollection<ProjectDao> projects)
    {
        this.projects = projects;
    }

    public ProjectDao[] GetAll()
    {
        _projectRepository ??= new ProjectRepository(projects);
        return _projectRepository.GetAll();
    }

    public ProjectDao? GetProjectDao(Guid id)
    {
        if (_projectRepository == null)
        {
            _projectRepository = new ProjectRepository(projects);
        }
        return _projectRepository.GetProjectDao(id);
    }

    public void SaveProject(ProjectDao project)
    {
        if (_projectRepository == null)
        {
            _projectRepository = new ProjectRepository(projects);
        }
        _projectRepository.SaveProject(project);
    }
}