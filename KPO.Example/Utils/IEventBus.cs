using KPO.DDD.Basic;

namespace KPO.Example.Utils;

public interface IEventBus
{
    void Publish<T>(T @event) where T : IEvent;
}