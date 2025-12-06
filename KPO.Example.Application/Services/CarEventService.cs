using KPO.Example.Application.Repositories;
using KPO.Example.Contracts.Events;
using MassTransit;

namespace KPO.Example.Application.Services;

public class CarEventService : ICarEventService
{
    private readonly IBus _bus;
    private readonly ICarEventRepository _carEventRepository;

    public CarEventService(IBus bus, ICarEventRepository carEventRepository)
    {
        _bus = bus;
        _carEventRepository = carEventRepository;
    }

    public async Task SendEvents(CancellationToken cancellation)
    {
        var events = await _carEventRepository.GetEvents(cancellation);
        foreach (var @event in events)
        {
            await _bus.Publish(new CarBuildEvent
            {
                Id = @event.Id,
                Name = @event.Name,
                Type = @event.Type
            }, cancellation);
            @event.IsCompleted = true;
        }
        
        await _carEventRepository.SaveEvents(cancellation);
    }
}