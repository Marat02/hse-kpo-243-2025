using KPO.Example.Application.Services;
using KPO.Example.Models.Cars;
using Microsoft.AspNetCore.Mvc;

namespace KPO.Example.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController : Controller
{
    private readonly IProjectService _projectService;

    public CarsController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    /// <summary>
    /// Создать машину
    /// </summary>
    /// <returns>Машина</returns>
    [HttpPost]
    public ICar CreateCar()
    {
        return _projectService.CreateCar();
    }
}