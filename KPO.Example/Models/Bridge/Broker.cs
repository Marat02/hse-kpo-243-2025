namespace KPO.Example.Models.Bridge;

public class Broker
{
    private readonly IClientSendMessage _client;

    public Broker(IClientSendMessage client)
    {
        _client = client;
    }

    public string Send()
    {
        return _client.SendMessage("Message");
    }
}