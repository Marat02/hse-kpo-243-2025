namespace KPO.Example.Application.Services;

public interface ICarEventService
{
    Task SendEvents(CancellationToken cancellation);
}