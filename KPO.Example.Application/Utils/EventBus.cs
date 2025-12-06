using KPO.DDD.Basic;
using KPO.Example.Utils;
using MassTransit;
using MediatR;

namespace KPO.Example.Application.Utils;

public class EventBus : IEventBus
{
    private readonly IBus _bus;

    public EventBus(IBus bus)
    {
        _bus = bus;
    }

    public void Publish<T>(T @event) where T : IEvent
    {
        _bus.Publish(@event);
    }
}