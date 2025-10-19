using KPO.Example.Models.Projects;

namespace KPO.Example.Infrastructure.Repositories;

/// <summary>
/// Репозиторий - адаптер для класса проект
/// </summary>
public class ProjectRepository : IProjectRepository
{
    private readonly Dictionary<Guid, ProjectDao> _projects;

    public ProjectRepository(IReadOnlyCollection<ProjectDao> projects)
    {
        _projects = projects.ToDictionary(p => p.Id);
    }

    public ProjectDao? GetProjectDao(Guid id)
    {
        return _projects.GetValueOrDefault(id);
    }

    public void SaveProject(ProjectDao project)
    {
        _projects[project.Id] = project;
    }
}