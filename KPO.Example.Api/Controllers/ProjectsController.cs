using KPO.Example.Api.Infos;
using KPO.Example.Api.Views;
using KPO.Example.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace KPO.Example.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : Controller
{
    private readonly IProjectService _projectService;

    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProjectView))]
    public async Task<ProjectView> CreateProject([FromBody] ProjectInfo info, 
        CancellationToken cancellation)
    {
        var project = await _projectService.CreateProject(info.Name, info.Target, cancellation);
        return new ProjectView(project.Id, project.Name, project.Target);
    }
    
    [HttpGet]
    public async Task<ProjectView[]> GetProjects(CancellationToken cancellation)
    {
        return (await _projectService.GetAllProjects(cancellation))
            .Select(p => new ProjectView(p.Id, p.Name, p.Target)).ToArray();
    }
}