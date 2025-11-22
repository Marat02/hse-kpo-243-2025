using KPO.Example.Models.Cars;
using KPO.Example.Models.Projects;

namespace KPO.Example.Application.Services;

public interface IProjectService
{
    Task<Project[]> GetAllProjects(CancellationToken cancellation);
    
    Task<Project> CreateProject(string name, string target, CancellationToken cancellation);

    Task<ICar> CreateCar(CancellationToken cancellation);
}