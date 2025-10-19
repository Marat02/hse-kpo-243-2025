namespace KPO.Example.Models.Bridge;

public class Client : IClient, IClientSendMessage
{
    public string SendMessage(string message)
    {
        return message;
    }

    public void ReceiveMessage(string message)
    {
    }

    public void SendFile(string file)
    {
    }

    public void ReceiveFile(string file)
    {
    }

    public void SendRequest(string request)
    {
    }

    public void ReceiveRequest(string request)
    {
    }

    public void SendResponse(string response)
    {
    }

    public void ReceiveResponse(string response)
    {
    }
}