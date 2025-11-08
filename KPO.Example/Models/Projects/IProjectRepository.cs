namespace KPO.Example.Models.Projects;

public interface IProjectRepository
{
    public ProjectDao? GetProjectDao(Guid id);
    
    public void SaveProject(ProjectDao project);
    public ProjectDao[] GetAllProjects();
}