using KPO.Example.Models.Cars;
using KPO.Example.Models.Projects;

namespace KPO.Example.Application.Services;

public interface IProjectService
{
    Project CreateProject(string name, string target);

    Project[] GetProjects();

    ICar CreateCar();
}