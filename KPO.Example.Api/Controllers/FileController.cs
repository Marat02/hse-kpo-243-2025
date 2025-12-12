using KPO.Example.Application.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KPO.Example.Api.Controllers;

[ApiController]
[Route("api/files")]
public class FileController : Controller
{
    private readonly IFileRepository _fileRepository;

    public FileController(IFileRepository fileRepository)
    {
        _fileRepository = fileRepository;
    }

    [HttpGet("{key}")]
    public async Task<IActionResult> Get(string key, CancellationToken cancellationToken)
    {
        return File(await _fileRepository.Get(key, cancellationToken), "application/octet-stream", key);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(IFormFile file, CancellationToken cancellationToken)
    {
        await _fileRepository.Save(file.FileName, file.OpenReadStream(), cancellationToken);
        return Ok();
    }
}