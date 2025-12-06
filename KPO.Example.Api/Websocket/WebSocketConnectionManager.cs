using System.Collections.Concurrent;
using System.Net.WebSockets;

namespace KPO.Example.Api.Websocket;

public class WebSocketConnectionManager
{
    private readonly ConcurrentDictionary<string, WebSocket> _sockets = new();

    public string AddSocket(WebSocket socket)
    {
        var id = Guid.NewGuid().ToString();
        _sockets.TryAdd(id, socket);
        return id;
    }

    public WebSocket? GetSocket(string id) => _sockets.GetValueOrDefault(id);

    public IEnumerable<WebSocket> GetAll() => _sockets.Values;

    public void RemoveSocket(string id) => _sockets.TryRemove(id, out _);
}