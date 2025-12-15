namespace KPO.Example.Models.Projects;

public interface IProjectRepository
{
    public Task<ProjectDao[]> GetAll(CancellationToken cancellation);
    
    public Task<ProjectDao?> GetProjectDao(Guid id, CancellationToken cancellation);
    
    public Task AddProject(ProjectDao project, CancellationToken cancellation);

    Task UpdateProject(ProjectDao dao, CancellationToken cancellation);
    
    Task<int> CountAll(CancellationToken cancellation);

    Task Remove(ProjectDao project, CancellationToken cancellation);
}