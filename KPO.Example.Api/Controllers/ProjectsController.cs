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
    public ProjectView CreateProject([FromBody] ProjectInfo info)
    {
        var project = _projectService.CreateProject(info.Name, info.Target);
        return new ProjectView(project.Id, project.Name, project.Target);
    }
    
    [HttpGet]
    public ProjectView[] GetProjects()
    {
        return _projectService.GetAllProjects().Select(p => new ProjectView(p.Id, p.Name, p.Target)).ToArray();
    }
}