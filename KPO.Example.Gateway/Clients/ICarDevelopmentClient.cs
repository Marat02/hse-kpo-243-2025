using KPO.Example.Contracts.Views;

namespace KPO.Example.Gateway.Clients;

public interface ICarDevelopmentClient
{
    Task<ProjectView[]> GetProjects(CancellationToken cancellationToken);
}