namespace KPO.Example.Application.Mediators;

public interface IMediator
{
    void Send(string message, object sender);
}