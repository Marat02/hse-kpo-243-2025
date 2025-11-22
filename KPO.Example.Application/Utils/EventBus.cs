using KPO.DDD.Basic;
using KPO.Example.Utils;
using MediatR;

namespace KPO.Example.Application.Utils;

public class EventBus : IEventBus
{
    private readonly IMediator _mediator;

    public EventBus(IMediator mediator)
    {
        _mediator = mediator;
    }

    public void Publish<T>(T @event) where T : IEvent
    {
        _mediator.Publish(@event);
    }
}