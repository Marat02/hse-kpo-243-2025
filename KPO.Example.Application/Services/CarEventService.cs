using KPO.Example.Application.Repositories;
using KPO.Example.Contracts.Events;
using MassTransit;

namespace KPO.Example.Application.Services;

public class CarEventService : ICarEventService
{
    private readonly ICarEventRepository _carEventRepository;
    private readonly IBus _bus;

    public CarEventService(ICarEventRepository carEventRepository, IBus bus)
    {
        _carEventRepository = carEventRepository;
        _bus = bus;
    }

    public async Task SendEvents(CancellationToken cancellation)
    {
        var events = await _carEventRepository.Get(cancellation);

        foreach (var @event in events)
        {
            try
            {
                await _bus.Publish(new CarBuildEvent
                {
                    Id = @event.Id,
                    Name = @event.Name,
                    Type = @event.Type
                }, cancellation);

                @event.IsSuccess = true;
            }
            catch
            {
                // ignored
            }
        }

        await _carEventRepository.Save(cancellation);
    }
}