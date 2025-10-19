namespace KPO.Example.Models.Bridge;

/// <summary>
/// Интерфейс - мост между клиентом и брокером
/// </summary>
public interface IClientSendMessage
{
    string SendMessage(string message);
}