using KPO.Example.Contracts.Views;
using KPO.Example.Models.Cars;
using KPO.Example.Models.Projects;

namespace KPO.Example.Application.Services;

public interface IProjectService
{
    Task<Project[]> GetAllProjects(CancellationToken cancellation);
    
    Task<Project> CreateProject(string name, string target, CancellationToken cancellation);

    Task<ICar> CreateCar(Guid id, int blueprintId, string name, CancellationToken cancellation);

    Task<Project> Update(Guid id, string name, string target, CancellationToken cancellation);
    
    Task<ProjectCountView> GetProjectCount(CancellationToken cancellation);
    
    Task DeleteProject(Guid id, CancellationToken cancellation);
}