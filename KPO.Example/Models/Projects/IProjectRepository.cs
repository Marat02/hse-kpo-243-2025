namespace KPO.Example.Models.Projects;

public interface IProjectRepository
{
    public ProjectDao[] GetAll();
    
    public ProjectDao? GetProjectDao(Guid id);
    
    public void SaveProject(ProjectDao project);
}