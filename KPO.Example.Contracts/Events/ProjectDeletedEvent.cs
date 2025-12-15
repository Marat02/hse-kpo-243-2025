using KPO.DDD.Basic;

namespace KPO.Example.Contracts.Events;

public record ProjectDeletedEvent(Guid Id, Guid EventId) : IEvent;