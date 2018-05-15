namespace Cqrs.Events
{
    using System;

    public abstract class BaseEvent : IEvent
    {
        public Guid EventId { get; protected set; } = Guid.NewGuid();
    }
}