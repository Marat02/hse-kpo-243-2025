using System.Diagnostics;
using KPO.Example.Application.Services;
using KPO.Example.Models.Projects;
using Microsoft.AspNetCore.Mvc;
using KPO.Example.MVC.Models;

namespace KPO.Example.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProjectService _projectService;

    public HomeController(ILogger<HomeController> logger, IProjectService projectService)
    {
        _logger = logger;
        _projectService = projectService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
    
    public async Task<IActionResult> Projects(CancellationToken cancellationToken)
    {
        return View(_projectService.GetAllProjects());
    }
    
    public async Task<IActionResult> Create(string projectName, CancellationToken cancellationToken)
    {
        _projectService.CreateProject(projectName, "Target");
        return RedirectToAction("Projects");
    }
}