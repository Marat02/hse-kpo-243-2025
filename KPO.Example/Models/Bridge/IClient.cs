namespace KPO.Example.Models.Bridge;

public interface IClient
{
    string SendMessage(string message);
    
    void ReceiveMessage(string message);
    
    void SendFile(string file);
    
    void ReceiveFile(string file);
    
    void SendRequest(string request);
    
    void ReceiveRequest(string request);
    
    void SendResponse(string response);
    
    void ReceiveResponse(string response);
}