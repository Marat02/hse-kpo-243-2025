using KPO.Example.Contracts.Views;
using KPO.Example.Gateway.Clients;
using Microsoft.AspNetCore.Mvc;

namespace KPO.Example.Gateway.Controllers;

[ApiController]
[Route("api/projects")]
public class ProjectsController : Controller
{
    private readonly ICarDevelopmentClient _carDevelopmentClient;

    public ProjectsController(ICarDevelopmentClient carDevelopmentClient)
    {
        _carDevelopmentClient = carDevelopmentClient;
    }

    [HttpGet]
    public async Task<ProjectView[]> GetProjects(CancellationToken cancellationToken)
    {
        return await _carDevelopmentClient.GetProjects(cancellationToken);
    }
}