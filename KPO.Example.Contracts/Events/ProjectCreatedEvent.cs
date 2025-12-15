using KPO.DDD.Basic;

namespace KPO.Example.Contracts.Events;

public record ProjectCreatedEvent(Guid Id, string Name, string Target, Guid EventId) : IEvent;