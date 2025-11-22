namespace KPO.Example.Models.Projects;

public interface IProjectRepository
{
    public Task<ProjectDao[]> GetAll(CancellationToken cancellation);
    
    public Task<ProjectDao?> GetProjectDao(Guid id, CancellationToken cancellation);
    
    public Task AddProject(ProjectDao project, CancellationToken cancellation);
}