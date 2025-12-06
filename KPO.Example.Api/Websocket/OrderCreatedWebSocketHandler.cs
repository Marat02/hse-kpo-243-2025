using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using KPO.Example.Contracts.Events;
using MediatR;

namespace KPO.Example.Api.Websocket;

public class OrderCreatedWebSocketHandler : INotificationHandler<CarBuildEvent>
{
    private readonly WebSocketConnectionManager _manager;

    public OrderCreatedWebSocketHandler(WebSocketConnectionManager manager)
    {
        _manager = manager;
    }

    public async Task Handle(CarBuildEvent @event, CancellationToken ct)
    {
        var message = JsonSerializer.Serialize(@event);
        var buffer = Encoding.UTF8.GetBytes(message);

        foreach (var socket in _manager.GetAll())
        {
            if (socket.State == WebSocketState.Open)
            {
                await socket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, ct);
            }
        }
    }
}