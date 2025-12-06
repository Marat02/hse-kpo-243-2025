using System.Net.WebSockets;
using KPO.Example.Api.Websocket;
using KPO.Example.Application.Services;
using KPO.Example.Contracts.Infos;
using KPO.Example.Contracts.Views;
using Microsoft.AspNetCore.Mvc;

namespace KPO.Example.Api.Controllers;

[ApiController]
[Route("api/projects")]
public class ProjectsController : Controller
{
    private readonly IProjectService _projectService;
    private readonly WebSocketConnectionManager _manager;

    public ProjectsController(IProjectService projectService, WebSocketConnectionManager manager)
    {
        _projectService = projectService;
        _manager = manager;
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

    [HttpPut("{id}")]
    public async Task<ProjectView> UpdateProject(Guid id, ProjectInfo info, CancellationToken cancellation)
    {
        var project = await _projectService.Update(id, info.Name, info.Target, cancellation);
        return await Task.FromResult(new ProjectView(Guid.NewGuid(), info.Name, info.Target));
    }

    [HttpPost("{id}/cars")]
    public async Task CreateCar(Guid id, [FromBody] CarInfo carInfo, CancellationToken cancellation)
    {
        await _projectService.CreateCar(id, carInfo.BlueprintId, carInfo.Name, cancellation);
    }

    [HttpGet]
    [Route("websockets")]
    public async Task Socket(CancellationToken cancellationToken)
    {
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
            var id = _manager.AddSocket(webSocket);

            try
            {
                await Echo(webSocket, cancellationToken);
            }
            finally
            {
                _manager.RemoveSocket(id);
                await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closed", cancellationToken);
            }
        }
        else
        {
            HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
    
    private async Task Echo(WebSocket webSocket, CancellationToken cancellationToken)
    {
        var buffer = new byte[1024 * 4];
        while (webSocket.State == WebSocketState.Open)
        {
            var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken);
        
            if (result.MessageType == WebSocketMessageType.Close)
            {
                await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", cancellationToken);
                break;
            }
        
            // Отправляем обратно полученные данные
            await webSocket.SendAsync(new ArraySegment<byte>(buffer, 0, result.Count), 
                result.MessageType, 
                result.EndOfMessage, 
                cancellationToken);
        }
    }
}